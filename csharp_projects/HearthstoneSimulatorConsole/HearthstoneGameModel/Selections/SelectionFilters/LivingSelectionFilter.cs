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
    public class LivingSelectionFilter : SelectionFilter
    {
        public override List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot)
        {
            return toFilter.Where(
                slot =>
                {
                    if (slot.CardType == CardType.Minion
                        || slot.CardType == CardType.Hero)
                    {
                        BattlerCardSlot battlerCardSlot = (BattlerCardSlot)slot;
                        if (battlerCardSlot.Health <= 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            ).ToList();
        }

        public override SelectionFilter Copy()
        {
            return new LivingSelectionFilter();
        }
    }
}
