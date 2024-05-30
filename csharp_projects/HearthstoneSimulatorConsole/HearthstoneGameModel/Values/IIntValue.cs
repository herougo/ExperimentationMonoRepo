using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Values
{
    public interface IIntValue
    {
        int Get(HearthstoneGame game, CardSlot affectedSlot);
    }
}
