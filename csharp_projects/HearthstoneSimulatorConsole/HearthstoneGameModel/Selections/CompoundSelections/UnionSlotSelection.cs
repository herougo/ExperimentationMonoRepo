using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CompoundSelections
{
    public class UnionSlotSelection : SlotSelection
    {
        protected SlotSelection _selection1;
        protected SlotSelection _selection2;

        public UnionSlotSelection(SlotSelection selection1, SlotSelection selection2)
        {
            _selection1 = selection1;
            _selection2 = selection2;
            _eventsReceived.AddRange(selection1.EventsReceived);
            _eventsReceived.AddRange(selection2.EventsReceived);
        }

        public override List<CardSlot> GetSelectedCardSlots
            (HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> results = _selection1.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            results.AddRange(_selection2.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot));
            return results;
        }

        public override SlotSelection Copy()
        {
            return new UnionSlotSelection(_selection1.Copy(), _selection2.Copy());
        }
    }
}
