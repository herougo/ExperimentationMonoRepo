using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class DivineShield : ContinuousEffect
    {
        public DivineShield()
        {
            _eventsReceived = new List<string> {
                EffectEvent.DamagePreparation
            };
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            bool removeEmNode = false;
            BattlerCardSlot cardSlot = (BattlerCardSlot)emNode.AffectedSlot;
            if (cardSlot.TempDamageToTake != 0)
            {
                cardSlot.TempDamageToTake = 0;
                removeEmNode = true;
            }

            if (removeEmNode)
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                plan.ToRemove.Add(emNode);
                return plan;
            }

            return null;
            
        }

        public override EMEffectType EffectType
        {
            get { return EMEffectType.DivineShield; }
        }

        public override EMEffect Copy()
        {
            return new DivineShield();
        }
    }
}
