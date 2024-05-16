using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class EventBasedEffect
    {
        protected List<string> _eventsReceived;
        protected bool _requiresSlotMatchForEvent = false;
        protected bool _requiresSlotPlayerMatchForEvent = false;

        public ReadOnlyCollection<string> EventsReceived {
            get { return _eventsReceived.AsReadOnly(); }
        }

        public bool RequiresSlotMatchForEvent { 
            get { return _requiresSlotMatchForEvent; }
        }

        public bool RequiresSlotPlayerMatchForEvent
        {
            get { return _requiresSlotPlayerMatchForEvent; }
        }

        public void AdjustStats()
        {

        }
    }
}
