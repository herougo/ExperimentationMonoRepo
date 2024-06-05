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
            int whoGoesSecond = HearthstoneConstants.NumberOfPlayers - 1;
            Hands = new Pile[HearthstoneConstants.NumberOfPlayers]
            {
                new Pile(),
                new Pile()
            };
            UIManager.ReceiveUIEvent(new PlayerGoingFirstUIEvent(GameMetadata.WhoGoesFirst));

            CardMover.DrawCards(GameMetadata.WhoGoesFirst, HearthstoneConstants.NumDrawsGoingFirst);
            CardMover.DrawCards(whoGoesSecond, HearthstoneConstants.NumDrawsGoingSecond);
            CreateCardAndAddToHand(whoGoesSecond, new Coin());

            if (mulligan)
            {
                throw new NotImplementedException("Mulligan not implemented");
            }

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
            Weapons = new WeaponCardSlot[HearthstoneConstants.NumberOfPlayers]
            {
                null, null
            };
            Battleboard = new Battleboard(this);

            addBasePlayerEffects(0);
            addBasePlayerEffects(1);
            GameMetadata.Turn = GameMetadata.WhoGoesFirst;
            foreach (HeroCardSlot player in Players)
            {
                player.MaximumMana = HearthstoneConstants.MaximumMana;
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
                for (int i = 0; i < HearthstoneConstants.MaxTurnNum; i++)
                {
                    EffectManager.SendEvent(EffectEvent.StartTurn);
                    UIManager.ReceiveUIEvent(new StartTurnUIEvent());

                    LoopActionsUntilEndTurn();

                    EffectManager.SendEvent(EffectEvent.PreEndTurnFrozen);
                    EffectManager.SendEvent(EffectEvent.EndTurn);

                    GameMetadata.Turn = 1 - GameMetadata.Turn;
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
            GameMetadata.AttackerDamageTaken = defenderCardSlot.Attack;
            GameMetadata.DefenderDamageTaken = attackerCardSlot.Attack;
            EffectManager.SendEvent(EffectEvent.AfterAttackerInitialCombatDamage);
            EffectManager.SendEvent(EffectEvent.AfterDefenderInitialCombatDamage);
            attackerCardSlot.TakeDamage(GameMetadata.AttackerDamageTaken);
            defenderCardSlot.TakeDamage(GameMetadata.DefenderDamageTaken);
            EffectManager.SendEvent(EffectEvent.AfterAttackerAttacked, attackerCardSlot);
            EffectManager.SendEvent(EffectEvent.AfterCombatDamage);

            if (attackerCardSlot.CardType == CardType.Hero
                && Weapons[attackerCardSlot.Player] != null)
            {
                Weapons[attackerCardSlot.Player].Durability -= 1;
                if (Weapons[attackerCardSlot.Player].Durability == 0)
                {
                    CardMover.DestroyWeapon(attackerCardSlot.Player);
                }
            }

            CheckGameOver();

            List<CardSlot> minionsToKill = new List<CardSlot>();
            if (attackerCardSlot.CardType == CardType.Minion
                && ((MinionCardSlot)attackerCardSlot).Health <= 0)
            {
                minionsToKill.Add(attackerCardSlot);
            }
            if (defenderCardSlot.CardType == CardType.Minion
                && ((MinionCardSlot)defenderCardSlot).Health <= 0)
            {
                minionsToKill.Add(defenderCardSlot);
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
    }
}
