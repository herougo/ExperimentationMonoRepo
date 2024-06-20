using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections
{
    public abstract class SelectionFilter : SlotSelection
    {
        protected SlotSelection _selection;

        public SelectionFilter(SlotSelection selection)
        {
            _selection = selection;
            _eventsReceived.AddRange(selection.EventsReceived);
        }

        protected abstract List<CardSlot> filter(List<CardSlot> toFilter);

        public override List<CardSlot> GetSelectedCardSlots
            (HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> results = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            results = filter(results);
            return results;
        }
    }
}
