using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Conditions
{
    public class WhileMinionPlayCountEquals : ICondition
    {
        private int _desiredCount;
        private List<string> _eventsReceived;

        public WhileMinionPlayCountEquals(int desiredCount)
        {
            _eventsReceived = new List<string>() { EffectEvent.StartTurn, EffectEvent.CardPlayed };
            _desiredCount = desiredCount;
        }

        public List<string> EventsReceived
        {
            get
            {
                return _eventsReceived;
            }
        }

        public bool Evaluate(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            return game.PlayerMetadata[player].MinionPlayCount == _desiredCount;
        }

        public ICondition Copy()
        {
            return new WhileMinionPlayCountEquals(_desiredCount);
        }
    }
}
