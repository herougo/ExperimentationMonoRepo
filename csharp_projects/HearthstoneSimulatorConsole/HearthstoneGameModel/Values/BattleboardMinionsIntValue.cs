using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Values
{
    public class BattleboardMinionsIntValue : IIntValue
    {
        public int Get(HearthstoneGame game, CardSlot affectedSlot)
        {
            return game.Battleboard.BoardLen(0) + game.Battleboard.BoardLen(1);
        }
    }
}
