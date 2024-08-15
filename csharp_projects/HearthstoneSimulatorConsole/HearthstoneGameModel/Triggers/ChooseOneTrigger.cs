using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class ChooseOneTrigger : Trigger
    {
        public ChooseOneTrigger()
        {
            _eventsReceived = new List<string> { EffectEvent.MinionChooseOne };
            _requiresSlotMatchForEvent = true;
        }

        public override Trigger Copy()
        {
            return new ChooseOneTrigger();
        }
    }
}
