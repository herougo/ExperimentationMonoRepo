﻿using System;
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

        public void SetupGame(bool shuffleDecks)
        {
            EffectManager = new EffectManager(this);
            Decks = new Pile[HearthstoneConstants.NumberOfPlayers]
            {
                new Pile(), // TODO
                new Pile()
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
                new Pile(), // TODO
                new Pile()
            };
            // TODO: log player going first

            CardMover.DrawCards(GameMetadata.WhoGoesFirst, HearthstoneConstants.NumDrawsGoingFirst);
            CardMover.DrawCards(whoGoesSecond, HearthstoneConstants.NumDrawsGoingSecond);
            // TODO: Coin CreateCardAndAddToHand(whoGoesSecond, Coin());

            // TODO: Mulligan

            Players = new HeroCardSlot[HearthstoneConstants.NumberOfPlayers]
            {
                new HeroCardSlot(Decklists[0].HeroClass, 0, this),
                new HeroCardSlot(Decklists[1].HeroClass, 1, this)
            };
            foreach (HeroCardSlot player in Players)
            {
                // player.SetupHeroPower(); TODO
            }
            Weapons = new WeaponCardSlot[HearthstoneConstants.NumberOfPlayers]
            {
                null, null
            };
            Battleboard = new Battleboard(this);

            // Set up in-game effects
            GameMetadata.Turn = GameMetadata.WhoGoesFirst;
            // TODO: Hero Effects
        }

        public void Play()
        {
            try
            {
                for (int i = 0; i < HearthstoneConstants.MaxTurnNum; i++)
                {
                    EffectManager.SendEvent(EffectEvent.StartTurn);
                    UIManager.ReceiveUIEvent(UIEvent.StartTurn);

                    LoopActionsUntilEndTurn();

                    UIManager.ReceiveUIEvent(UIEvent.EndTurnSelected);
                    EffectManager.SendEvent(EffectEvent.PreEndTurnFrozen);
                    EffectManager.SendEvent(EffectEvent.EndTurn);

                    GameMetadata.Turn = 1 - GameMetadata.Turn;
                }
            }
            catch (GameOverException ex)
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
            }
            GameMetadata.ReadyToEndTurn = false;
        }

        public void CreateCardAndAddToHand(int player, Card card)
        {
            int numCanDraw = PlayerMetadata[player].HandLimit - Hands[player].Length;
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
            UIManager.ReceiveUIEvent(UIEvent.GameOver); // TODO: send arguments
            throw new GameOverException();
        }

        public void Attack(CardSlot attackerCardSlot, CardSlot defenderCardSlot)
        {
            // TODO: UIManager
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
                    CardMover.DestroyWeapon(attackerCardSlot.player);
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
        }
    }
}