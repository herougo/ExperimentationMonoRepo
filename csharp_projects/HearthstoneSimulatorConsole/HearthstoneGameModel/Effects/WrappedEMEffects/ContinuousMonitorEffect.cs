using HearthstoneGameModel.Conditions;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.ValueMonitors;

namespace HearthstoneGameModel.Effects.WrappedEMEffects
{
    public class ContinuousMonitorEffect : WrappedEMEffect
    {
        protected IntValueMonitor _monitor;
        protected bool _memoryCurrentCondEval = false;

        public ContinuousMonitorEffect(EMEffect effect, IntValueMonitor monitor)
        : base(effect)
        {
            _monitor = monitor;
            _eventsReceived.AddRange(monitor.EventsReceived);
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            if (_monitor.EventsReceived.Contains(effectEvent))
            {
                plan.UpdateStats.Add(emNode.AffectedSlot);
            }
            if (_effect.EventsReceived.Contains(effectEvent))
            {
                plan.Update(_effect.SendEvent(effectEvent, game, emNode, eventSlots));
            }
            return plan;
        }

        public override EMEffect Copy()
        {
            return new ContinuousMonitorEffect(_effect.Copy(), _monitor.Copy());
        }
    }
}
