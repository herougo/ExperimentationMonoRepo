using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class ActivatedEffect : TriggerEffect
    {
        // these effects are "triggered" by events caused by user input (e.g. "hero_power")

        public ActivatedEffect(OneTimeEffect effect)
            : base(effect) { }
    }
}
