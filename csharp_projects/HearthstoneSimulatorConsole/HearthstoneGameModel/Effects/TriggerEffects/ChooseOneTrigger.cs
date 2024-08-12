using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class ChooseOneTrigger : TriggerEffect
    {
        public ChooseOneTrigger(ChooseOne effect)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionChooseOne };
            _requiresSlotMatchForEvent = true;
        }

        public override EMEffect Copy()
        {
            return new ChooseOneTrigger((ChooseOne)_effect.Copy());
        }
    }
}
