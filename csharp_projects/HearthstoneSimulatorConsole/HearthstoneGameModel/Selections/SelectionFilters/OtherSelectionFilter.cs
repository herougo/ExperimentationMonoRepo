using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class OtherSelectionFilter : SelectionFilter
    {
        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(slot => slot != affectedCardSlot).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new OtherSelectionFilter();
        }
    }
}
