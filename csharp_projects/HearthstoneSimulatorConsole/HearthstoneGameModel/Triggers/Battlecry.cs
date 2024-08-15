using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class Battlecry : TriggerEffect
    {
        public Battlecry(OneTimeEffect effect)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionBattlecry };
            _requiresSlotMatchForEvent = true;
        }

        public override EMEffect Copy()
        {
            return new Battlecry(_effect.Copy());
        }
    }
}
