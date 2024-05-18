using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.Action
{
    public class ArrayStringActionReader : IStringActionReader
    {
        string[] _data;
        int lastIndex = -1;

        public ArrayStringActionReader(string[] data)
        {
            _data = data;
        }

        public string GetAction()
        {
            lastIndex += 1;
            return _data[lastIndex];
        }
    }
}
