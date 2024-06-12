using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EffectEventArgs
    {
        public string EffectEvent;
        public CardSlot EventSlot = null;

        public EffectEventArgs(string effectEvent) {
            EffectEvent = effectEvent;
        }

        public EffectEventArgs(string effectEvent, CardSlot eventSlot)
        {
            EffectEvent = effectEvent;
            EventSlot = eventSlot;
        }
    }
}
