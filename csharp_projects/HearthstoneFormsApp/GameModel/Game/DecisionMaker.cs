using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel.Game
{
    public class DecisionMaker
    {
        public ActionGetter ActionGetter;
        HearthstoneGame _game = null;

        public DecisionMaker(ActionGetter actionGetter)
        {
            ActionGetter = actionGetter;
        }

        public void SetGame(HearthstoneGame game)
        {
            _game = game;
        }
    }
}
