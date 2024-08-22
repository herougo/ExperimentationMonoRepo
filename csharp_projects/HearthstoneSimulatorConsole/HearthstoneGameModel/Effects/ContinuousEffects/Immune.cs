using HearthstoneGameModel.Core;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Immune : ContinuousEffect
    {
        public Immune()
        {
            _eventsReceived = new List<string> { EffectEvent.DamagePreparation };
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            BattlerCardSlot cardSlot = (BattlerCardSlot)emNode.AffectedSlot;
            cardSlot.TempDamageToTake = 0;
            return null;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumImmune += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumImmune -= 1;
            if (typedSlot.NumImmune < 0)
            {
                throw new AssertionException("NumImmune < 0");
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Immune();
        }
    }
}
