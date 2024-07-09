using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Stealth : ContinuousEffect
    {
        public Stealth()
        {
            _eventsReceived = new List<string> { EffectEvent.AfterAttackerAttacked };
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumStealth += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumStealth -= 1;
            if (typedSlot.NumStealth < 0)
            {
                throw new AssertionException("NumStealth < 0");
            }
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.ToRemove.Add(emNode);
            return plan;
        }

        public override EMEffect Copy()
        {
            return new Stealth();
        }
    }
}
