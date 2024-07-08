using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedEMEffects
{
    public class ExternalEffect : WrappedEMEffect
    {
        public ExternalEffect(EMEffect effect) : base(effect) {
            _priority = 1;
        }

        public override bool IsExternal { get { return true; } }

        public override EMEffect Copy()
        {
            return new ExternalEffect(_effect.Copy());
        }
    }
}
