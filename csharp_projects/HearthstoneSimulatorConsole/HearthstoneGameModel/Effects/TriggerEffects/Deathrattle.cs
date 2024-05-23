using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class Deathrattle : TriggerEffect
    {
        public Deathrattle(OneTimeEffect effect)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _requiresSlotMatchForEvent = true;
        }

        public override EMEffect Copy()
        {
            return new Deathrattle(_effect.Copy());
        }
    }
}
