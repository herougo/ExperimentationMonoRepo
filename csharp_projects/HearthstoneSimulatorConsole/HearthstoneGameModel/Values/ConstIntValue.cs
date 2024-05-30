using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Values
{
    public class ConstIntValue : IIntValue
    {
        private int _value;

        public ConstIntValue(int value) {
            _value = value;
        }

        public int Get(HearthstoneGame game, CardSlot affectedSlot)
        {
            return _value;
        }
    }
}
