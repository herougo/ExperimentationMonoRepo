using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class HearthstoneGameArgs
    {
        public Decklist[] Decklists;
        public DecisionMaker[] DecisionMakers;
        public HearthstoneGameArgs(
            Decklist decklist0, Decklist decklist1,
            DecisionMaker decisionMaker0, DecisionMaker decisionMaker1)
        {
            Decklists = new Decklist[HearthstoneConstants.NumberOfPlayers] {
                decklist0, decklist1
            };
            DecisionMakers = new DecisionMaker[HearthstoneConstants.NumberOfPlayers] {
                decisionMaker0, decisionMaker1
            };
        }
    }
}
