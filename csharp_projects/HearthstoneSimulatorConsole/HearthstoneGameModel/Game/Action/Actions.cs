using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;

namespace HearthstoneGameModel.Game.Action
{
    public interface IAction
    {
        string ActionType { get; }

        void Perform(HearthstoneGame game);
    }

    public class EndTurnAction : IAction
    {
        public string ActionType
        {
            get { return Actions.EndTurn; }
        }

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

        public string ActionType
        {
            get { return Actions.Attack; }
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

        public string ActionType
        {
            get { return Actions.Play; }
        }

        public void Perform(HearthstoneGame game)
        {
            game.CardMover.PlayCard(_cardInHandIndex, _destinationIndex);
        }
    }

    public class HeroPowerAction : IAction
    {
        public string ActionType
        {
            get { return Actions.HeroPower; }
        }

        public void Perform(HearthstoneGame game)
        {
            int turn = game.GameMetadata.Turn;
            game.PlayerMetadata[turn].CurrentMana -= game.Players[turn].HeroPowerCost;
            game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.ActivateHeroPower, game.Players[turn]));
            game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.HeroPowerEnd, game.Players[turn]));
        }
    }

    public class ConcedeAction : IAction
    {
        public string ActionType
        {
            get { return Actions.Concede; }
        }

        public void Perform(HearthstoneGame game)
        {
            int turn = game.GameMetadata.Turn;
            game.EndGame(turn == 0, turn == 1);
        }
    }

    public class SelectAction : IAction
    {
        CardSlot _selection;

        public SelectAction(CardSlot selection)
        {
            _selection = selection;
        }

        public CardSlot Selection { get { return _selection; } }

        public string ActionType
        {
            get { return Actions.Select; }
        }

        public void Perform(HearthstoneGame game) { }
    }
}
