using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections
{
    public class FilteredSelection : SlotSelection
    {
        protected SlotSelection _selection;
        protected SelectionFilter _filter;

        public FilteredSelection(SlotSelection selection, SelectionFilter filter)
        {
            _selection = selection;
            _eventsReceived.AddRange(selection.EventsReceived);
            _filter = filter;
        }

        public override List<CardSlot> GetSelectedCardSlots
            (HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> results = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            results = _filter.Filter(results, game, affectedCardSlot);
            return results;
        }

        public override SlotSelection Copy()
        {
            return new FilteredSelection(_selection.Copy(), _filter.Copy());
        }
    }
}
