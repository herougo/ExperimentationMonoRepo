using HearthstoneGameModel.Game.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.UI;

namespace HearthstoneGameModel.Game
{
    public class HearthstoneGameArgs
    {
        public Decklist[] Decklists;
        public PlayerDecisionMaker[] DecisionMakers;
        public UIManager UIManager;
        public HearthstoneGameArgs(
            Decklist decklist0, Decklist decklist1,
            PlayerDecisionMaker decisionMaker0, PlayerDecisionMaker decisionMaker1,
            UIManager uiManager)
        {
            Decklists = new Decklist[HearthstoneConstants.NumberOfPlayers] {
                decklist0, decklist1
            };
            DecisionMakers = new PlayerDecisionMaker[HearthstoneConstants.NumberOfPlayers] {
                decisionMaker0, decisionMaker1
            };
            UIManager = uiManager;
        }
    }
}
