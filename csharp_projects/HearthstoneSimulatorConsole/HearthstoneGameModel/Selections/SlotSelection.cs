using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.Action;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections.CompoundSelections;
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
        public static SlotSelection operator +(SlotSelection a, SlotSelection b) {
            return new UnionSlotSelection(a, b);
        }
        public static SlotSelection operator &(SlotSelection a, SelectionFilter b)
        {
            return new FilteredSelection(a, b);
        }

        public abstract SlotSelection Copy();


    }
}
