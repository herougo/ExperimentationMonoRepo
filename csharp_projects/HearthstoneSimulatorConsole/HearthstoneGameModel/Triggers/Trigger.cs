using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public abstract class Trigger
    {
        protected List<string> _eventsReceived = new List<string>();
        protected bool _requiresSlotMatchForEvent = false;
        protected bool _requiresSlotPlayerMatchForEvent = false;

        public List<string> EventsReceived { get { return _eventsReceived; } }

        public bool RequiresSlotMatchForEvent { get {  return _requiresSlotMatchForEvent; } }

        public bool RequiresSlotPlayerMatchForEvent { get { return _requiresSlotPlayerMatchForEvent; } }

        public virtual bool ShouldRun(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            return true;
        }

        public abstract Trigger Copy();
    }
}
