using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Game.Action
{
    public interface IAction
    {
        void Perform(HearthstoneGame game);
    }

    public class EndTurnAction : IAction
    {
        public void Perform(HearthstoneGame game)
        {
            game.GameMetadata.ReadyToEndTurn = true;
        }
    }

    public class AttackAction : IAction
    {
        BattlerCardSlot _attackerCardSlot;
        BattlerCardSlot _defenderCardSlot;
        public AttackAction(BattlerCardSlot attackerCardSlot, BattlerCardSlot defenderCardSlot)
        {
            _attackerCardSlot = attackerCardSlot;
            _defenderCardSlot = defenderCardSlot;
        }
        public void Perform(HearthstoneGame game)
        {
            game.Attack(_attackerCardSlot, _defenderCardSlot);
        }
    }

    public class PlayCardAction : IAction
    {
        int _cardInHandIndex;
        int _destinationIndex;

        public PlayCardAction(int cardInHandIndex, int destinationIndex)
        {
            _cardInHandIndex = cardInHandIndex;
            _destinationIndex = destinationIndex;
        }

        public void Perform(HearthstoneGame game)
        {
            game.CardMover.PlayCard(_cardInHandIndex, _destinationIndex);
        }
    }

    public class HeroPowerAction : IAction
    {
        public void Perform(HearthstoneGame game)
        {
            int turn = game.GameMetadata.Turn;
            game.Players[turn].CurrentMana -= game.Players[turn].HeroPowerCost;
            game.EffectManager.SendEvent(EffectEvent.ActivateHeroPower, game.Players[turn]);
            game.EffectManager.SendEvent(EffectEvent.HeroPowerEnd, game.Players[turn]);
        }
    }

    public class ConcedeAction : IAction
    {
        public void Perform(HearthstoneGame game)
        {
            int turn = game.GameMetadata.Turn;
            game.EndGame(turn == 0, turn == 1);
        }
    }
}
