using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections
{
    public abstract class SlotSelection
    {
        protected List<string> _eventsReceived = new List<string>();

        public List<string> EventsReceived { get {  return _eventsReceived; } }

        public abstract List<CardSlot> GetSelectedCardSlots
            (HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        );

        public abstract SlotSelection Copy();
    }
}
