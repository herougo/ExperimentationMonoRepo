using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;

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
                throw new Exception("Action is empty");
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
                case Actions.Concede:
                    return new ConcedeAction();
                default:
                    throw new Exception("Unhandled Action");
            }
        }

        public AttackAction ParseAttackAction(string[] actionSplit)
        {
            if (actionSplit.Length != 3)
            {
                throw new Exception("Attack actions need 2 arguments.");
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
                throw new Exception("Invalid action argument type");
            }


            int attackerBoardSize = _game.Battleboard.BoardLen(attackerTurn);
            int defenderBoardSize = _game.Battleboard.BoardLen(defenderTurn);

            if (attackerIndex < HearthstoneConstants.HeroIndex
                || attackerIndex >= attackerBoardSize)
            {
                throw new Exception("attacker outside range");
            }

            if (defenderIndex < HearthstoneConstants.HeroIndex
                || defenderIndex >= defenderBoardSize)
            {
                throw new Exception("defender outside range");
            }

            CardSlot attackerSlot = _game.Battleboard.GetSlot(attackerTurn, attackerIndex);
            CardSlot defenderSlot = _game.Battleboard.GetSlot(defenderTurn, defenderIndex);

            BattlerCardSlot attackerBattlerSlot, defenderBattlerSlot;
            try
            {
                attackerBattlerSlot = (BattlerCardSlot)attackerSlot;
                defenderBattlerSlot = (BattlerCardSlot)defenderSlot;
            }
            catch {
                throw new Exception("Attacker or defender is not a battler card");
            }

            CanAttackResponse canAttackResponse = CanVoluntarilyAttack(attackerBattlerSlot, defenderBattlerSlot);
            if (canAttackResponse != CanAttackResponse.Yes)
            {
                switch (canAttackResponse)
                {
                    case CanAttackResponse.ZeroAttack:
                        throw new Exception("attacker has 0 attack");
                    case CanAttackResponse.Frozen:
                        throw new Exception("attacker is frozen");
                    case CanAttackResponse.AttackedEnough:
                        throw new Exception("attacker attacked enough (already attacked enough)");
                    case CanAttackResponse.Asleep:
                        throw new Exception("attacker cannot attack (asleep)");
                    case CanAttackResponse.DisobeysTaunt:
                        throw new Exception("attack disobey taunt");
                    case CanAttackResponse.DefenderHasStealth:
                        throw new Exception("defender cannot be attacked (stealth)");
                }
            }
            return new AttackAction(attackerBattlerSlot, defenderBattlerSlot) ;
         }

        public CanAttackResponse CanVoluntarilyAttack(BattlerCardSlot attacker, BattlerCardSlot defender)
        {
            if (attacker.Attack == 0)
            {
                return CanAttackResponse.ZeroAttack;
            }
            else if  (attacker.IsFrozen)
            {
                return CanAttackResponse.Frozen;
            }
            else if (attacker.AttacksThisTurn >= attacker.NumPossibleAttacksIgnoringFrozen)
            {
                return CanAttackResponse.AttackedEnough;
            }
            else if (attacker.HasCharge)
            {

            }
            else if (attacker.HasSleep)
            {
                return CanAttackResponse.Asleep;
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
                throw new Exception("PlayCard actions need at least 1 arugment");
            }

            string cardInHandIndexString = actionSplit[1];
            int cardInHandIndex;
            try
            {
                cardInHandIndex = Int32.Parse(cardInHandIndexString);
            }
            catch
            {
                throw new Exception("Invalid action argument type");
            }

            int turn = _game.GameMetadata.Turn;
            int handSize = _game.Hands[turn].Count;
            if (cardInHandIndex < 0 || handSize <= cardInHandIndex) {
                throw new Exception("card index outside range");
            }

            CardSlot cardSlot = _game.Hands[turn][cardInHandIndex];
            if (cardSlot.Mana > _game.Players[turn].CurrentMana)
            {
                throw new Exception("not enough mana to play the card");
            }

            if (cardSlot.CardType == CardType.Minion)
            {
                MinionCardSlot cardSlotTyped = (MinionCardSlot)cardSlot;

                if (actionSplit.Length != 3)
                {
                    throw new Exception("PlayCard actions for minions need 2 arugments");
                }

                string destinationIndexString = actionSplit[2];
                int destinationIndex;
                try
                {
                    destinationIndex = Int32.Parse(destinationIndexString);
                }
                catch
                {
                    throw new Exception("Invalid action argument type");
                }

                int playerBoardSize = _game.Battleboard.BoardLen(turn);
                if (destinationIndex < 0 || playerBoardSize < destinationIndex)
                {
                    throw new Exception("destination index outside range");
                }

                if (!_game.Battleboard.HasRoom(turn))
                {
                    throw new Exception("not enough space on the battleboard");
                }

                return new PlayCardAction(cardInHandIndex, destinationIndex);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
