using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.Action;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Metadata;
using HearthstoneGameModel.Core;
using System.Linq.Expressions;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.UI;
using HearthstoneGameModel.UI.UIEvents;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Cards.Implementations;

namespace HearthstoneGameModel.Game
{
    public class HearthstoneGame
    {
        public Decklist[] Decklists;
        public PlayerDecisionMaker[] DecisionMakers;
        public Pile[] Decks;
        public Pile[] Hands;
        public HeroCardSlot[] Players;
        public WeaponCardSlot[] Weapons;
        public Battleboard Battleboard;

        public EffectManager EffectManager;
        public GameMetadata GameMetadata;
        public PlayerMetadata[] PlayerMetadata;
        public CardMover CardMover;

        public UIManager UIManager;

        public GraveyardTracker GraveyardTracker;

        public HearthstoneGame(HearthstoneGameArgs args)
        {
            Decklists = args.Decklists;
            DecisionMakers = args.DecisionMakers;
            foreach (PlayerDecisionMaker decisionMaker in DecisionMakers)
            {
                decisionMaker.SetGame(this);
            }
            UIManager = args.UIManager;
            UIManager.SetGame(this);

            Decks = null;
            Hands = null;
            Players = null;
            Weapons = null;
            Battleboard = null;

            EffectManager = null;
            GameMetadata = null;
            PlayerMetadata = null;
            GraveyardTracker = null;
            CardMover = new CardMover(this);
        }

        public void SetupGame(bool shuffleDecks, bool mulligan)
        {
            EffectManager = new EffectManager(this);
            Decks = new Pile[HearthstoneConstants.NumberOfPlayers]
            {
                Decklists[0].ToPile(0, this),
                Decklists[1].ToPile(1, this)
            };
            if (shuffleDecks)
            {
                for (int i = 0; i < HearthstoneConstants.NumberOfPlayers; i++)
                {
                    Decks[i].Shuffle();
                }
            }
            GameMetadata = new GameMetadata();
            PlayerMetadata = new PlayerMetadata[HearthstoneConstants.NumberOfPlayers]
            {
                new PlayerMetadata(),
                new PlayerMetadata()
            };
            GameMetadata.WhoGoesFirst = 0;
            GameMetadata.TurnCount = 0;
            int whoGoesSecond = HearthstoneConstants.NumberOfPlayers - 1;
            Hands = new Pile[HearthstoneConstants.NumberOfPlayers]
            {
                new Pile(),
                new Pile()
            };
            Weapons = new WeaponCardSlot[HearthstoneConstants.NumberOfPlayers]
            {
                null, null
            };
            UIManager.ReceiveUIEvent(new PlayerGoingFirstUIEvent(GameMetadata.WhoGoesFirst));

            Players = new HeroCardSlot[HearthstoneConstants.NumberOfPlayers]
            {
                new HeroCardSlot(Decklists[0].HeroClass, 0, this),
                new HeroCardSlot(Decklists[1].HeroClass, 1, this)
            };
            foreach (HeroCardSlot player in Players)
            {
                player.Health = HearthstoneConstants.HeroHealth;
                player.MaxHealth = HearthstoneConstants.HeroHealth;
                player.SetupHeroPower();
            }
            Battleboard = new Battleboard(this);
            GraveyardTracker = new GraveyardTracker();

            addBasePlayerEffects(0);
            addBasePlayerEffects(1);
            GameMetadata.Turn = GameMetadata.WhoGoesFirst;
            foreach (PlayerMetadata playerMetadata in PlayerMetadata)
            {
                playerMetadata.MaximumMana = HearthstoneConstants.MaximumMana;
            }

            CardMover.DrawCards(GameMetadata.WhoGoesFirst, HearthstoneConstants.NumDrawsGoingFirst);
            CardMover.DrawCards(whoGoesSecond, HearthstoneConstants.NumDrawsGoingSecond);
            CreateCardAndAddToHand(whoGoesSecond, new Coin());

            if (mulligan)
            {
                throw new NotImplementedException("Mulligan not implemented");
            }
        }

        private void addBasePlayerEffects(int player)
        {
            EMEffect drawEffect = new OnTurnStart(new DrawCards(SelectionConstants.Player, 1));
            EMEffect gainManaEffect = new OnTurnStart(new GainManaCrystals(SelectionConstants.Player, 1));
            EMEffect refreshManaEffect = new OnTurnStart(new RefreshAllManaCrystals(SelectionConstants.Player));
            EMEffect refreshMinionAttacks = new OnTurnEnd(new RefreshAttacks(SelectionConstants.AllFriendlyCharacters));
            EMEffect refreshHeroPower = new OnTurnEnd(new RefreshHeroPower(SelectionConstants.Player));

            List<EMEffect> effects = new List<EMEffect> {
                drawEffect, gainManaEffect, refreshManaEffect, refreshMinionAttacks, refreshHeroPower
            };
            
            foreach (EMEffect effect in effects)
            {
                EffectManagerNode emNode = new EffectManagerNode(effect, Players[player], Players[player], false);
                EffectManager.AddEffect(emNode);
            }
        }

        public void Play()
        {
            try
            {
                while (GameMetadata.TurnCount < HearthstoneConstants.MaxTurnNum)
                {
                    EffectManager.SendEvent(EffectEvent.StartTurn);
                    UIManager.ReceiveUIEvent(new StartTurnUIEvent());

                    LoopActionsUntilEndTurn();

                    EffectManager.SendEvent(EffectEvent.PreEndTurnFrozen);
                    EffectManager.SendEvent(EffectEvent.EndTurn);

                    GameMetadata.Turn = 1 - GameMetadata.Turn;
                    GameMetadata.TurnCount += 1;
                }
            }
            catch (GameOverException)
            {

            }
        }

        public void LoopActionsUntilEndTurn()
        {
            int turn = GameMetadata.Turn;

            while (!GameMetadata.ReadyToEndTurn)
            {
                IAction action;
                try
                {
                    action = DecisionMakers[turn].GetAction();
                }
                catch (Exception ex)
                {
                    UIManager.LogError(ex.Message);
                    continue;
                }
                action.Perform(this);
                UIManager.ReceiveUIEvent(new ActionCompletedUIEvent());
            }
            GameMetadata.ReadyToEndTurn = false;
        }

        public void CreateCardAndAddToHand(int player, Card card)
        {
            int numCanDraw = PlayerMetadata[player].HandLimit - Hands[player].Count;
            if (numCanDraw > 0)
            {
                CardSlot cardSlot = card.CreateCardSlot(player, this);
                Hands[player].AddCard(cardSlot);

                EffectManager.AddInHandEffects(cardSlot);
                EffectManager.SendEvent(new EffectEventArgs(EffectEvent.CardMovedToHand, cardSlot));
            }
        }

        public CardSlot IndexToSlot(int player, int boardIndex)
        {
            if (boardIndex == HearthstoneConstants.HeroIndex)
            {
                return Players[player];
            }
            else
            {
                return Battleboard.GetSlot(player, boardIndex);
            }
        }

        public void CheckGameOver()
        {
            bool player0Dead = Players[0].Health <= 0;
            bool player1Dead = Players[1].Health <= 0;
            if (!player0Dead && !player1Dead)
            {
                return;
            }
            EndGame(player0Dead, player1Dead);
        }

        public void EndGame(bool player0Dead, bool player1Dead)
        {
            GameOverUIEvent uiEvent = new GameOverUIEvent(player0Dead, player1Dead);
            UIManager.ReceiveUIEvent(uiEvent);
            throw new GameOverException();
        }

        public void Attack(BattlerCardSlot attackerCardSlot, BattlerCardSlot defenderCardSlot)
        {
            UIManager.ReceiveUIEvent(new AttackUIEvent(attackerCardSlot, defenderCardSlot));
            attackerCardSlot.AttacksThisTurn += 1;
            attackerCardSlot.TempDamageToTake = defenderCardSlot.Attack;
            defenderCardSlot.TempDamageToTake = attackerCardSlot.Attack;
            EffectManager.SendEvent(new EffectEventArgs(EffectEvent.DamagePreparation, attackerCardSlot));
            EffectManager.SendEvent(new EffectEventArgs(EffectEvent.DamagePreparation, defenderCardSlot));

            EffectManagerNodePlan attackerPlan = attackerCardSlot.TakeDamage();
            attackerPlan.Perform(EffectManager);
            EffectManagerNodePlan defenderPlan = defenderCardSlot.TakeDamage();
            defenderPlan.Perform(EffectManager);
            EffectManager.SendEvent(new EffectEventArgs(EffectEvent.InflictDamage, new List<CardSlot>() { defenderCardSlot, attackerCardSlot }));
            EffectManager.SendEvent(new EffectEventArgs(EffectEvent.InflictDamage, new List<CardSlot>() { attackerCardSlot, defenderCardSlot }));

            attackerCardSlot.TempDamageToTake = 0;
            defenderCardSlot.TempDamageToTake = 0;

            EffectManager.SendEvent(new EffectEventArgs(EffectEvent.AfterAttackerAttacked, attackerCardSlot)); // TODO: after KillIfNecessary
            EffectManager.SendEvent(EffectEvent.AfterCombatDamage);

            if (attackerCardSlot.CardType == CardType.Hero
                && Weapons[attackerCardSlot.Player] != null)
            {
                ReduceDurability(attackerCardSlot.Player);
            }

            KillIfNecessary();
        }

        public void ReduceDurability(int player)
        {
            Weapons[player].Durability -= 1;
            if (Weapons[player].Durability == 0)
            {
                CardMover.DestroyWeapon(player);
            }
        }

        public void KillIfNecessary()
        {
            CheckGameOver();

            List<CardSlot> minionsToKill = new List<CardSlot>();
            for (int player = 0; player < HearthstoneConstants.NumberOfPlayers; player++)
            {
                foreach (CardSlot slot in Battleboard.GetAllSlots(player))
                {
                    if (slot.CardType == CardType.Minion)
                    {
                        MinionCardSlot minionSlot = (MinionCardSlot)slot;
                        if (minionSlot.Health <= 0 || minionSlot.IsDestroyed) {
                            minionsToKill.Add(slot);
                        }
                    }
                }
            }
            CardMover.KillMinions(minionsToKill);
        }

        public CardSlot GetSelectionFromAction(List<CardSlot> options, int player)
        {
            DecisionMaker decisionMaker = DecisionMakers[player];
            while (true)
            {
                try
                {
                    IAction action = decisionMaker.GetAction();
                    SelectAction selectAction = (SelectAction)action;
                    CardSlot selectedSlot = selectAction.Selection;

                    if (!options.Contains(selectedSlot))
                    {
                        throw new ActionException("selected card is not one of the possible options");
                    }

                    return selectedSlot;
                }
                catch (ActionException ex)
                {
                    UIManager.LogError(ex.Message);
                }
            }
        }

        public int GetChoiceFromAction(int numChoices, int player)
        {
            DecisionMaker decisionMaker = DecisionMakers[player];
            while (true)
            {
                try
                {
                    IAction action = decisionMaker.GetAction();
                    ChooseAction choiceAction = (ChooseAction)action;
                    int choice = choiceAction.Choice;

                    if (choice < 0 || numChoices <= choice)
                    {
                        throw new ActionException("choice is not one of the possible options");
                    }

                    return choice;
                }
                catch (ActionException ex)
                {
                    UIManager.LogError(ex.Message);
                }
            }
        }

        public void DealDamage(CardSlot sourceSlot, List<BattlerCardSlot> targetSlots, int amount)
        {
            if (sourceSlot.CardType == CardType.Spell)
            {
                amount += PlayerMetadata[sourceSlot.Player].SpellDamage;
            }
            foreach (BattlerCardSlot targetSlot in targetSlots)
            {
                targetSlot.TempDamageToTake = amount;
            }

            foreach (BattlerCardSlot targetSlot in targetSlots)
            {
                EffectManager.SendEvent(new EffectEventArgs(EffectEvent.DamagePreparation, targetSlot));
            }

            EffectManagerNodePlan targetPlan = new EffectManagerNodePlan();
            foreach (BattlerCardSlot targetSlot in targetSlots)
            {
                targetPlan.Update(targetSlot.TakeDamage());
            }
            targetPlan.Perform(EffectManager);

            foreach (BattlerCardSlot targetSlot in targetSlots)
            {
                EffectManager.SendEvent(new EffectEventArgs(EffectEvent.InflictDamage, new List<CardSlot>() { targetSlot, sourceSlot }));
                targetSlot.TempDamageToTake = 0;
            }
        }

        public EffectManagerNodePlan InPlayTransform(MinionCardSlot cardInPlay, Card transformFinalForm)
        {
            CardSlot transformFinalFormSlot = transformFinalForm.CreateCardSlot(cardInPlay.Player, this);

            // replace slot
            Battleboard.ReplaceCardSlot(cardInPlay, transformFinalFormSlot);
            CardMover.SendCardToLimbo(cardInPlay);
            EffectManager.PopEffectsBySlot(cardInPlay);
            CardMover.RemoveCardSlot(cardInPlay);

            // In-play changes
            EffectManager.AddInPlayEffects(cardInPlay);
            cardInPlay.AddSleepEffectManagerNode();

            // other
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.MinionTransformed, transformFinalFormSlot));
            return plan;
        }
    }
}
