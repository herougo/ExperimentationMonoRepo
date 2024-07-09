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
        public List<CardSlot> EventSlots;

        public EffectEventArgs(string effectEvent) {
            EffectEvent = effectEvent;
            EventSlots = new List<CardSlot>() { null };
        }

        public EffectEventArgs(string effectEvent, List<CardSlot> eventSlots)
        {
            EffectEvent = effectEvent;

            if (eventSlots.Count == 0)
            {
                EventSlots = new List<CardSlot>() { null };
            }
            EventSlots = eventSlots;
        }

        public EffectEventArgs(string effectEvent, CardSlot eventSlot)
        {
            EffectEvent = effectEvent;
            EventSlots = new List<CardSlot> { eventSlot };
        }
    }
}
