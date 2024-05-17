using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Sleep : ContinuousEffect
    {
        public Sleep() {
            _eventsReceived.Add(EffectEvent.EndTurn);
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot slot = (BattlerCardSlot)emNode.AffectedSlot;
            slot.HasSleep = true;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot slot = (BattlerCardSlot)emNode.AffectedSlot;
            slot.HasSleep = false;
            return null;
        }

        public override EMEffect Copy()
        {
            return new Sleep();
        }
    }
}
