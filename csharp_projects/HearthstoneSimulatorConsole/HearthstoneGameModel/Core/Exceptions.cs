using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core
{
    public class GameOverException : Exception
    {
        public GameOverException() :base("Game Over") { }
    }
}
