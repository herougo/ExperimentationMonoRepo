using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections
{
    public abstract class SelectionFilter
    {
        public abstract List<CardSlot> Filter(List<CardSlot> toFilter, HearthstoneGame game, CardSlot affectedCardSlot);

        public abstract SelectionFilter Copy();
    }
}
