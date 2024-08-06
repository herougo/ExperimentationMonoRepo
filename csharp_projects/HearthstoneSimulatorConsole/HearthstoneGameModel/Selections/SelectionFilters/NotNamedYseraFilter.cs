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
    public class NotNamedYseraFilter : SelectionFilter
    {
        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(
                slot =>
                {
                    switch (slot.Card.CardId)
                    {
                        case CardIds.Ysera:
                            return false;
                        default:
                            return true;
                    }
                }
            ).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new NotNamedYseraFilter();
        }
    }
}
