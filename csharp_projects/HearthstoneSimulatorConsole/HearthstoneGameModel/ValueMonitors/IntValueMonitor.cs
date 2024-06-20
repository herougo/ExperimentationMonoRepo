using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.ValueMonitors
{
    public abstract class IntValueMonitor
    {
        protected List<string> _eventsReceived = new List<string>();

        public List<string> EventsReceived { get { return _eventsReceived; } }

        public abstract IntValueMonitor Copy();
    }
}
