using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Metadata;

namespace HearthstoneGameModel.Game.Action
{
    public class StringActionParser
    {
        HearthstoneGame _game = null;

        public StringActionParser(HearthstoneGame game)
        {
            _game = game;
        }

        public IAction Parse(string action)
        {
            string[] split = action.Split(' ');
            if (split.Length == 0) {
                throw new ArgumentException("Action is empty");
            }
            string actionType = split[0];
            switch (actionType)
            {
                case Actions.EndTurn:
                    return new EndTurnAction();
                case Actions.Attack:
                    return ParseAttackAction(split);
                case Actions.Play:
                    return ParsePlayCardAction(split);
                case Actions.HeroPower:
                    return ParseHeroPowerAction(split);
                case Actions.Select:
                    return ParseSelectAction(split);
                case Actions.Concede:
                    return new ConcedeAction();
                default:
                    throw new NotImplementedException("Unhandled Action: " + actionType);
            }
        }

        public AttackAction ParseAttackAction(string[] actionSplit)
        {
            if (actionSplit.Length != 3)
            {
                throw new ActionException("Attack actions need 2 arguments.");
            }

            int attackerTurn = _game.GameMetadata.Turn;
            int defenderTurn = 1 - attackerTurn;

            int attackerIndex, defenderIndex;
            try
            {
                attackerIndex = Int32.Parse(actionSplit[1]);
                defenderIndex = Int32.Parse(actionSplit[2]);
            }
            catch
            {
                throw new ActionException("Invalid action argument type");
            }


            int attackerBoardSize = _game.Battleboard.BoardLen(attackerTurn);
            int defenderBoardSize = _game.Battleboard.BoardLen(defenderTurn);

            if (attackerIndex < HearthstoneConstants.HeroIndex
                || attackerIndex >= attackerBoardSize)
            {
                throw new ActionException("attacker outside range");
            }

            if (defenderIndex < HearthstoneConstants.HeroIndex
                || defenderIndex >= defenderBoardSize)
            {
                throw new ActionException("defender outside range");
            }

            CardSlot attackerSlot = _game.IndexToSlot(attackerTurn, attackerIndex);
            CardSlot defenderSlot = _game.IndexToSlot(defenderTurn, defenderIndex);

            BattlerCardSlot attackerBattlerSlot, defenderBattlerSlot;
            try
            {
                attackerBattlerSlot = (BattlerCardSlot)attackerSlot;
                defenderBattlerSlot = (BattlerCardSlot)defenderSlot;
            }
            catch {
                throw new ActionException("Attacker or defender is not a battler card");
            }

            CanAttackResponse canAttackResponse = CanVoluntarilyAttack(attackerBattlerSlot, defenderBattlerSlot);
            if (canAttackResponse != CanAttackResponse.Yes)
            {
                switch (canAttackResponse)
                {
                    case CanAttackResponse.CantAttackEffect:
                        throw new ActionException("attacker has the can't attack effect");
                    case CanAttackResponse.ZeroAttack:
                        throw new ActionException("attacker has 0 attack");
                    case CanAttackResponse.Frozen:
                        throw new ActionException("attacker is frozen");
                    case CanAttackResponse.AttackedEnough:
                        throw new ActionException("attacker attacked enough (already attacked enough)");
                    case CanAttackResponse.Asleep:
                        throw new ActionException("attacker cannot attack (asleep)");
                    case CanAttackResponse.DisobeysTaunt:
                        throw new ActionException("attack disobeys taunt");
                    case CanAttackResponse.DefenderHasStealth:
                        throw new ActionException("defender cannot be attacked (stealth)");
                }
            }
            return new AttackAction(attackerBattlerSlot, defenderBattlerSlot) ;
         }

        public CanAttackResponse CanVoluntarilyAttack(BattlerCardSlot attacker, BattlerCardSlot defender)
        {
            if (attacker.IsFrozen)
            {
                return CanAttackResponse.Frozen;
            }

            CanAttackResponse attackerCanAttack = attacker.CanAttackIgnoringFrozen;
            if (attackerCanAttack != CanAttackResponse.Yes)
            {
                return attackerCanAttack;
            }            

            if (!_game.Battleboard.DefenderObeysTaunt(defender))
            {
                return CanAttackResponse.DisobeysTaunt;
            }
            else if (defender.HasStealth)
            {
                return CanAttackResponse.DefenderHasStealth;
            }

            return CanAttackResponse.Yes;
        }

        public PlayCardAction ParsePlayCardAction(string[] actionSplit)
        {
            if (actionSplit.Length == 1)
            {
                throw new ActionException("PlayCard actions need at least 1 arugment");
            }

            string cardInHandIndexString = actionSplit[1];
            int cardInHandIndex;
            try
            {
                cardInHandIndex = Int32.Parse(cardInHandIndexString);
            }
            catch
            {
                throw new ActionException("Invalid action argument type");
            }

            int turn = _game.GameMetadata.Turn;
            int handSize = _game.Hands[turn].Count;
            if (cardInHandIndex < 0 || handSize <= cardInHandIndex) {
                throw new ActionException("card index outside range");
            }

            CardSlot cardSlot = _game.Hands[turn][cardInHandIndex];
            if (cardSlot.Mana > _game.PlayerMetadata[turn].CurrentMana)
            {
                throw new ActionException("not enough mana to play the card");
            }

            if (cardSlot.CardType == CardType.Minion)
            {
                if (actionSplit.Length != 3)
                {
                    throw new ActionException("PlayCard actions for minions need 2 arugments");
                }

                string destinationIndexString = actionSplit[2];
                int destinationIndex;
                try
                {
                    destinationIndex = Int32.Parse(destinationIndexString);
                }
                catch
                {
                    throw new ActionException("Invalid action argument type");
                }

                int playerBoardSize = _game.Battleboard.BoardLen(turn);
                if (destinationIndex < 0 || playerBoardSize < destinationIndex)
                {
                    throw new ActionException("destination index outside range");
                }

                if (!_game.Battleboard.HasRoom(turn))
                {
                    throw new ActionException("not enough space on the battleboard");
                }

                return new PlayCardAction(cardInHandIndex, destinationIndex);
            }
            else if (cardSlot.CardType == CardType.Spell)
            {
                if (actionSplit.Length != 2)
                {
                    throw new ActionException("PlayCard actions for spells need 1 arugment");
                }
                return new PlayCardAction(cardInHandIndex, HearthstoneConstants.NullInt);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public HeroPowerAction ParseHeroPowerAction(string[] actionSplit)
        {
            int player = _game.GameMetadata.Turn;
            PlayerMetadata playerMetadata = _game.PlayerMetadata[player];
            HeroCardSlot playerSlot = _game.Players[player];
            int manaCost = playerSlot.HeroPowerCost;
            if (playerMetadata.HeroPowerUsedThisTurn)
            {
                throw new ActionException("Hero power already used");
            }
            if (manaCost > _game.PlayerMetadata[_game.GameMetadata.Turn].CurrentMana)
            {
                throw new ActionException("Not enough Mana for hero power");
            }
            return new HeroPowerAction();
        }

        public SelectAction ParseSelectAction(string[] actionSplit)
        {
            if (actionSplit.Length != 3)
            {
                throw new ActionException("Attack actions need 2 arguments.");
            }

            int playerIndex, boardIndex;
            try
            {
                playerIndex = Int32.Parse(actionSplit[1]);
                boardIndex = Int32.Parse(actionSplit[2]);
            }
            catch
            {
                throw new ActionException("Invalid select action argument type");
            }

            CardSlot targetSlot = _game.IndexToSlot(playerIndex, boardIndex);
            if (targetSlot == null)
            {
                throw new ActionException("Invalid selection");
            }

            return new SelectAction(targetSlot);
        }
    }
}
