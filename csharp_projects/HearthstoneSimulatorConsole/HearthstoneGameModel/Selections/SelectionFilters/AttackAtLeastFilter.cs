using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class AttackAtLeastFilter : SelectionFilter
    {
        int _lowerBound;

        public AttackAtLeastFilter(int lowerBound)
        {
            _lowerBound = lowerBound;
        }

        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(slot => ((MinionCardSlot)slot).Attack >= _lowerBound).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new AttackAtLeastFilter(_lowerBound);
        }
    }
}
