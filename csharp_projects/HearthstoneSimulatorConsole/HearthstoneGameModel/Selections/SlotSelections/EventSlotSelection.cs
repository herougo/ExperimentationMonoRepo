using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class EventSlotSelection : SlotSelection
    {
        int _index;

        public EventSlotSelection(int index)
        {
            _index = index;
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            return new List<CardSlot> { eventSlots[_index] };
        }

        public override SlotSelection Copy()
        {
            return new EventSlotSelection(_index);
        }
    }
}
