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
    public class WhileMinionPlayCountEquals : Condition
    {
        private int _desiredCount;

        public WhileMinionPlayCountEquals(int desiredCount)
        {
            _eventsReceived = new List<string>() { EffectEvent.StartTurn, EffectEvent.CardPlayed };
            _desiredCount = desiredCount;
        }

        public override bool Evaluate(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            int player = emNode.AffectedSlot.Player;
            return game.PlayerMetadata[player].MinionPlayCount == _desiredCount;
        }

        public override Condition Copy()
        {
            return new WhileMinionPlayCountEquals(_desiredCount);
        }
    }
}
