using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class CardTypeSelectionFilter : SelectionFilter
    {
        CardType _desiredCardType;

        public CardTypeSelectionFilter(SlotSelection selection, CardType desiredCardType)
        : base(selection) {
            _desiredCardType = desiredCardType;
        }

        protected override List<CardSlot> filter(List<CardSlot> toFilter)
        {
            return toFilter.Where(slot => slot.CardType == _desiredCardType).ToList();
        }

        public override SlotSelection Copy()
        {
            return new CardTypeSelectionFilter(_selection.Copy(), _desiredCardType);
        }
    }
}
