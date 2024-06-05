using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.Action;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextView;

namespace TextViewBasedTests.Utils
{
    public static class GameBuilders
    {
        public static HearthstoneGame BuildWispPaladinGame(string actionInput, ITextLogger textLogger)
        {
            string[] actionInputSplit = actionInput.Replace("\r", "").Split("\n");

            RandomGenerator.SetSeed(0);
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string hsClass0 = "hero_paladin";
            Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
            Decklist decklist1 = new Decklist(cardIdList0, hsClass0);
            ArrayStringActionReader actionGetter = new ArrayStringActionReader(actionInputSplit);
            PlayerDecisionMaker decisionMaker0 = new PlayerDecisionMaker(actionGetter);
            PlayerDecisionMaker decisionMaker1 = new PlayerDecisionMaker(actionGetter);
            TextUIManager textUIManager = new TextUIManager(textLogger);

            HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
                decklist0, decklist1, decisionMaker0, decisionMaker1, textUIManager
            );
            HearthstoneGame game = new HearthstoneGame(hsArgs);
            return game;
        }

        public static HearthstoneGame BuildPaladinGame(
            string actionInput, ITextLogger textLogger,
            List<string> cardIdList0, List<string> cardIdList1)
        {
            string[] actionInputSplit = actionInput.Replace("\r", "").Split("\n");

            RandomGenerator.SetSeed(0);
            string hsClass0 = "hero_paladin";
            Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
            Decklist decklist1 = new Decklist(cardIdList1, hsClass0);
            ArrayStringActionReader actionGetter = new ArrayStringActionReader(actionInputSplit);
            PlayerDecisionMaker decisionMaker0 = new PlayerDecisionMaker(actionGetter);
            PlayerDecisionMaker decisionMaker1 = new PlayerDecisionMaker(actionGetter);
            TextUIManager textUIManager = new TextUIManager(textLogger);

            HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
                decklist0, decklist1, decisionMaker0, decisionMaker1, textUIManager
            );
            HearthstoneGame game = new HearthstoneGame(hsArgs);
            return game;
        }
    }
}
