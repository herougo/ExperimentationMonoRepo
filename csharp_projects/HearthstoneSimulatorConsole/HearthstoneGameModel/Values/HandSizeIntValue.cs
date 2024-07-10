using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Values
{
    public class HandSizeIntValue : IIntValue
    {
        public int Get(HearthstoneGame game, CardSlot affectedSlot)
        {
            int player = affectedSlot.Player;
            return game.Hands[player].Count();
        }
    }
}
