using System;
using System.Collections.Generic;
using System.Linq;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Metadata;
using HearthstoneGameModel.UI;
using HearthstoneGameModel.UI.UIEvents;

namespace HearthstoneGameModel.Game
{
    public class CardMover
    {
        HearthstoneGame _game;
        HashSet<CardSlot> _limbo = new HashSet<CardSlot>();

        public CardMover(HearthstoneGame game)
        {
            _game = game;
        }

        public void PlayCard(int cardInHandIndex, int destinationIndex)
        {
            int player = _game.GameMetadata.Turn;
            CardSlot cardSlot = _game.Hands[player].Pop(cardInHandIndex);
            PlayerMetadata playerMetadata = _game.PlayerMetadata[player];

            playerMetadata.CurrentMana -= cardSlot.Mana;

            _game.EffectManager.PopEffectsBySlot(cardSlot, true);

            string cardName = cardSlot.Card.Name;
            _game.UIManager.ReceiveUIEvent(new PlayCardUIEvent(cardName));

            CardType cardType = cardSlot.CardType;
            switch (cardType)
            {
                case CardType.Minion:
                    playMinion((MinionCardSlot)cardSlot, destinationIndex);
                    break;
                case CardType.Spell:
                    playSpell((SpellCardSlot)cardSlot);
                    break;
                case CardType.Weapon:
                    playWeapon((WeaponCardSlot)cardSlot);
                    break;
                default:
                    throw new NotImplementedException("PlayCard");
            }
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.CardPlayed, cardSlot));
        }

        private void playMinion(MinionCardSlot cardSlot, int destinationIndex)
        {
            _game.Battleboard.AddCards(
                cardSlot.Player, new List<CardSlot> { cardSlot },
                destinationIndex
            );

            _game.EffectManager.AddInPlayEffects(cardSlot);

            // prevent attacking on the turn it's summoned (via Sleep effect)
            cardSlot.AddSleepEffectManagerNode();

            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionChooseOne, cardSlot));
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionPutInPlay, cardSlot));
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WhenCardPlayed, cardSlot));
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionBattlecry, cardSlot));
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionSummoned, cardSlot));

            _game.PlayerMetadata[_game.GameMetadata.Turn].MinionPlayCount += 1;
        }

        private void playSpell(SpellCardSlot cardSlot)
        {
            SendCardToLimbo(cardSlot);

            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WhenCardPlayed, cardSlot));

            OneTimeEffect effect = cardSlot.TypedCard.WhenPlayedEffect;
            _game.EffectManager.ExecuteSpell(effect, cardSlot);

            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.AfterSpellActivated, cardSlot));
            RemoveCardSlot(cardSlot);
        }

        private void playWeapon(WeaponCardSlot cardSlot)
        {
            EquipWeapon(_game.GameMetadata.Turn, cardSlot);
            _game.EffectManager.AddInPlayEffects(cardSlot);

            // _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionChooseOne, cardSlot));
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WhenCardPlayed, cardSlot));
            // _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionBattlecry, cardSlot));
        }

        public void KillMinions(List<CardSlot> cardSlots)
        {
            foreach (CardSlot cardSlot in cardSlots)
            {
                _game.Battleboard.PopCardSlot(cardSlot);
                SendCardToLimbo(cardSlot);
            }

            foreach (CardSlot cardSlot in cardSlots)
            {
                _game.UIManager.ReceiveUIEvent(
                    new MinionDiedUIEvent(cardSlot.Player, cardSlot.Card.CardId)
                );
                _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionDies, cardSlot));
            }

            foreach (CardSlot cardSlot in cardSlots)
            {

                _game.EffectManager.PopEffectsBySlot(cardSlot);
                _game.GraveyardTracker.Add(
                    new GraveyardTrackerEntry(cardSlot.Card.Copy(), cardSlot.Player, _game.GameMetadata.TurnCount)
                );
                RemoveCardSlot(cardSlot);
            }
        }

        public void DrawCards(int player, int numCards)
        {
            int numCanDraw = _game.PlayerMetadata[player].HandLimit - _game.Hands[player].Count;
            int numBurned = Math.Max(0, numCards - numCanDraw);
            int numDrawn = numCards - numBurned;
            List<CardSlot> drawnCards = _game.Decks[player].Draw(numDrawn);
            List<CardSlot> burnedCards = _game.Decks[player].Draw(numBurned);
            
            _game.Hands[player].AddCards(drawnCards);
            foreach (CardSlot cardSlot in drawnCards)
            {
                _game.EffectManager.AddInHandEffects(cardSlot);
                _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.CardMovedToHand, cardSlot));
            }

            foreach (CardSlot cardSlot in burnedCards)
            {
                SendCardToLimbo(cardSlot);
                RemoveCardSlot(cardSlot);
                _game.UIManager.ReceiveUIEvent(
                    new CardBurnedUIEvent(cardSlot.Player, cardSlot.Card.Name)
                );
            }
        }

        public void SendCardToLimbo(CardSlot cardSlot)
        {
            _limbo.Add(cardSlot);
        }

        public void RemoveCardSlot(CardSlot cardSlot)
        {
            _limbo.Remove(cardSlot);
        }

        public void DestroyWeapon(int player)
        {
            WeaponCardSlot weaponCardSlot = _game.Weapons[player];
            SendCardToLimbo(weaponCardSlot);
            _game.Weapons[player] = null; // Must be set to None before sending event
            _game.Players[player].UpdateStats();
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WeaponDestroyed, weaponCardSlot));
            // _game.EffectManager.PopEffectsBySlot(weaponCardSlot);
            RemoveCardSlot(weaponCardSlot);
        }

        public void EquipWeapon(int player, WeaponCardSlot cardSlot)
        {
            if (_game.Weapons[player] != null)
            {
                DestroyWeapon(player);
            }
            _game.Weapons[player] = cardSlot; // Must be set before sending event
            _game.Weapons[player].UpdateStats();
            _game.Players[player].UpdateStats();
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WeaponEquipped, cardSlot));
        }

        public void SummonMinion(MinionCardSlot cardSlot)
        {
            _game.Battleboard.AddCards(cardSlot.Player, new List<CardSlot>{ cardSlot });

            string cardName = cardSlot.Card.Name;
            _game.UIManager.ReceiveUIEvent(new SummonMinionUIEvent(cardSlot.Player, cardName));

            _game.EffectManager.AddInPlayEffects(cardSlot);

            // prevent attacking on the turn it's summoned (via Sleep effect)
            cardSlot.AddSleepEffectManagerNode();

            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionPutInPlay, cardSlot));
            // (no battlecry event)
            _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionSummoned, cardSlot));
        }

        public void ReturnMinionsToHand(int player, List<CardSlot> cardSlots)
        {
            int availableHandSpace = _game.PlayerMetadata[player].HandLimit - _game.Hands[player].Count;
            int numToDie = Math.Max(cardSlots.Count - availableHandSpace, 0);
            int numToReturn = cardSlots.Count - numToDie;

            List<CardSlot> toReturn = cardSlots.GetRange(0, numToReturn);
            List<CardSlot> toDie = cardSlots.GetRange(numToReturn, numToDie);

            foreach (CardSlot cardSlot in toReturn)
            {
                _game.Battleboard.PopCardSlot(cardSlot);
                if (player !=  cardSlot.Player)
                {
                    cardSlot.SwitchPlayers();
                }
            }
            _game.Hands[player].AddCards(toReturn);

            foreach (CardSlot cardSlot in toReturn)
            {
                // TODO: UIManager
                _game.EffectManager.PopEffectsBySlot(cardSlot);

                _game.EffectManager.AddInHandEffects(cardSlot);

                _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.MinionReturnedToHand, cardSlot));
                _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.CardMovedToHand, cardSlot));
            }

            KillMinions(toDie);
        }

        public void DiscardCards(List<CardSlot> cardSlots)
        {
            List<CardSlot> cardSlots0 = cardSlots.Where(x => x.Player == 0).ToList();
            List<CardSlot> cardSlots1 = cardSlots.Where(x => x.Player == 1).ToList();

            _game.Hands[0].PopByCardSlots(cardSlots0);
            _game.Hands[1].PopByCardSlots(cardSlots1);
            foreach (CardSlot cardSlot in cardSlots)
            {
                SendCardToLimbo(cardSlot);
            }
            
            foreach (CardSlot cardSlot in cardSlots)
            {
                _game.UIManager.ReceiveUIEvent(
                    new CardDiscardedUIEvent(cardSlot.Player, cardSlot.Card.Name)
                );
                _game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.CardDiscarded, cardSlot));
            }

            foreach (CardSlot cardSlot in cardSlots)
            {
                _game.EffectManager.PopEffectsBySlot(cardSlot);
                RemoveCardSlot(cardSlot);
            }
        }
    }
}
