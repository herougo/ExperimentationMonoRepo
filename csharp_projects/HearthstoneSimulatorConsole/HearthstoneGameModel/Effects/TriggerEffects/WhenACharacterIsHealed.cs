using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.TriggerEffects
{
    public class WhenACharacterIsHealed : TriggerEffect
    {
        public WhenACharacterIsHealed(OneTimeEffect effect)
            : base(effect)
        {
            _eventsReceived = new List<string> { EffectEvent.CharacterHealed };
        }

        public override EMEffect Copy()
        {
            return new WhenACharacterIsHealed(_effect.Copy());
        }
    }
}
