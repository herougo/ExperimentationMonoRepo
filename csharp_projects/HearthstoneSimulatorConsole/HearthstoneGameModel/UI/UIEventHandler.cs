using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.UI
{
    public abstract class UIEventHandler
    {
        public abstract void Handle(HearthstoneGame game);
    }
}
