using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Game.Action
{
    public class StringActionParser
    {
        HearthstoneGame _game = null;

        public StringActionParser(HearthstoneGame game)
        {
            _game = game;
        }

        public IAction Parse(string action)
        {
            string[] split = action.Split(' ');
            if (split.Length == 0) {
                throw new Exception("Action is empty");
            }
            string actionType = split[0];
            switch (actionType)
            {
                case Actions.EndTurn:
                    return new EndTurnAction();
                default:
                    throw new Exception("Unhandled Action");
            }
        }
    }
}
