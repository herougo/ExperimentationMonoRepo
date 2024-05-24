using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedEMEffects
{
    public class ExternalEffect : WrappedEMEffect
    {
        public ExternalEffect(EMEffect effect) : base(effect) { }

        public override EMEffect Copy()
        {
            return new ExternalEffect(_effect.Copy());
        }
    }
}
