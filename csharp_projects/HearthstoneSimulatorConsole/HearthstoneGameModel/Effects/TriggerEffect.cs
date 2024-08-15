using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Effects
{
    public class TriggerEffect : EMEffect
    {
        protected Trigger _trigger;
        protected OneTimeEffect _effect;

        public TriggerEffect(Trigger trigger, OneTimeEffect effect)
        {
            _trigger = trigger;
            loadTriggerProperties();
            _effect = effect;
        }

        private void loadTriggerProperties()
        {
            _eventsReceived.AddRange(_trigger.EventsReceived);
            _requiresSlotMatchForEvent = _trigger.RequiresSlotMatchForEvent;
            _requiresSlotPlayerMatchForEvent = _trigger.RequiresSlotPlayerMatchForEvent;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (!_trigger.ShouldRun(effectEvent, game, emNode, eventSlots))
            {
                return null;
            }
            return _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot, eventSlots);
        }

        public override EMEffect Copy()
        {
            return new TriggerEffect(_trigger.Copy(), _effect.Copy());
        }
    }
}
