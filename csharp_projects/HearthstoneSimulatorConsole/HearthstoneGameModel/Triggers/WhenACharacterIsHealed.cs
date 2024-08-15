using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class WhenACharacterIsHealed : Trigger
    {
        public WhenACharacterIsHealed()
        {
            _eventsReceived = new List<string> { EffectEvent.CharacterHealed };
        }

        public override Trigger Copy()
        {
            return new WhenACharacterIsHealed();
        }
    }
}
