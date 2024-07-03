using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class TagSelectionFilter : SelectionFilter
    {
        MinionTag _desiredTag;

        public TagSelectionFilter(MinionTag desiredTag)
        {
            _desiredTag = desiredTag;
        }

        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(slot => HSGameUtils.MatchesTag(_desiredTag, ((MinionCard)slot.Card).Tag)).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new TagSelectionFilter(_desiredTag);
        }
    }
}
