using System;
using System.Collections.Generic;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
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
            CardSlot cardSlot = _game.Hands[_game.GameMetadata.Turn].Pop(cardInHandIndex);
            _game.Players[_game.GameMetadata.Turn].CurrentMana -= cardSlot.Mana;

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
                default:
                    throw new NotImplementedException("PlayCard");
            }
        }

        private void playMinion(CardSlot cardSlot, int destinationIndex)
        {
            _game.Battleboard.AddCards(
                cardSlot.Player, new List<CardSlot> { cardSlot },
                destinationIndex
            );

            foreach (EMEffect effect in cardSlot.Card.InPlayEffects)
            {
                EffectManagerNode emNode = new EffectManagerNode(
                    effect, cardSlot, cardSlot, true
                );
                _game.EffectManager.AddEffect(emNode);
            }

            // prevent attacking on the turn it's summoned (via Sleep effect)
            EffectManagerNode sleepEmNode = new EffectManagerNode(
                new Sleep(), cardSlot, cardSlot, false
            );
            _game.EffectManager.AddEffect(sleepEmNode);


            _game.EffectManager.SendEvent(EffectEvent.MinionPutInPlay, cardSlot);
            _game.EffectManager.SendEvent(EffectEvent.MinionBattlecry, cardSlot);
            _game.EffectManager.SendEvent(EffectEvent.MinionSummoned, cardSlot);
        }

        private void playSpell(SpellCardSlot cardSlot)
        {
            SendCardToLimbo(cardSlot);
            OneTimeEffect effect = cardSlot.TypedCard.WhenPlayedEffect;
            _game.EffectManager.Execute(effect, _game, cardSlot);

            _game.EffectManager.SendEvent(EffectEvent.AfterSpellActivated, cardSlot);
            RemoveCardSlot(cardSlot);
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
                _game.EffectManager.SendEvent(EffectEvent.MinionDies, cardSlot);
            }

            foreach (CardSlot cardSlot in cardSlots)
            {

                _game.EffectManager.PopEffectsBySlot(cardSlot);
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
            _game.EffectManager.SendEvent(EffectEvent.WeaponDestroyed, weaponCardSlot);
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
            _game.EffectManager.SendEvent(EffectEvent.WeaponEquipped, cardSlot);
        }

        public void SummonMinion(CardSlot cardSlot)
        {
            _game.Battleboard.AddCards(cardSlot.Player, new List<CardSlot>{ cardSlot });

            string cardName = cardSlot.Card.Name;
            _game.UIManager.ReceiveUIEvent(new SummonMinionUIEvent(cardSlot.Player, cardName));

            foreach (EMEffect effect in cardSlot.Card.InPlayEffects)
            {
                EffectManagerNode emNode = new EffectManagerNode(
                    effect, cardSlot, cardSlot, true
                );
                _game.EffectManager.AddEffect(emNode);
            }

            // prevent attacking on the turn it's summoned (via Sleep effect)
            EffectManagerNode sleepEmNode = new EffectManagerNode(
                new Sleep(), cardSlot, cardSlot, false
            );
            _game.EffectManager.AddEffect(sleepEmNode);


            _game.EffectManager.SendEvent(EffectEvent.MinionPutInPlay, cardSlot);
            // (no battlecry event)
            _game.EffectManager.SendEvent(EffectEvent.MinionSummoned, cardSlot);
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
                _game.EffectManager.SendEvent(EffectEvent.MinionReturnedToHand, cardSlot);
                _game.EffectManager.PopEffectsBySlot(cardSlot);
            }

            KillMinions(toDie);
        }
    }
}
