using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Conditions
{
    public abstract class Condition
    {
        protected List<string> _eventsReceived;

        public List<string> EventsReceived { get { return _eventsReceived; } }

        // Note: Evaluate should handle null effectEvent and empty eventSlots gracefully
        public abstract bool Evaluate(string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots);

        public abstract Condition Copy();
    }
}
