using HearthstoneGameModel.Game;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Action;
using TextView;

List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
string hsClass0 = "????";
Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
Decklist decklist1 = new Decklist(cardIdList0, hsClass0);
ConsoleActionReader actionGetter = new ConsoleActionReader();
PlayerDecisionMaker decisionMaker0 = new PlayerDecisionMaker(actionGetter);
PlayerDecisionMaker decisionMaker1 = new PlayerDecisionMaker(actionGetter);
TextUIManager textUIManager = new TextUIManager();

HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
    decklist0, decklist1, decisionMaker0, decisionMaker1, textUIManager
);
HearthstoneGame game = new HearthstoneGame(hsArgs);
game.SetupGame(false);
game.Play();