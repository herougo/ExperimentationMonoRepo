using HearthstoneGameModel.Game;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Actions;

List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
string hsClass0 = "????";
Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
Decklist decklist1 = new Decklist(cardIdList0, hsClass0);
ConsoleActionGetter actionGetter = new ConsoleActionGetter();
DecisionMaker decisionMaker0 = new DecisionMaker(actionGetter);
DecisionMaker decisionMaker1 = new DecisionMaker(actionGetter);

HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
    decklist0, decklist1, decisionMaker0, decisionMaker1
);
HearthstoneGame game = new HearthstoneGame(hsArgs);
game.SetupGame(false);
// game.Play();