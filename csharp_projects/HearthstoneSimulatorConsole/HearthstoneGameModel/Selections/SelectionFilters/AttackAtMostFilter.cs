using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SelectionFilters
{
    public class AttackAtMostFilter : SelectionFilter
    {
        int _upperBound;

        public AttackAtMostFilter(int upperBound)
        {
            _upperBound = upperBound;
        }

        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(slot => ((MinionCardSlot)slot).Attack <= _upperBound).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new AttackAtMostFilter(_upperBound);
        }
    }
}
