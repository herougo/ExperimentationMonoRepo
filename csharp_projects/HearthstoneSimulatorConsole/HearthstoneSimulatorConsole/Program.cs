using HearthstoneGameModel.Game;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Action;
using TextView;

List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentSquire, 30).ToList();
List<string> cardIdList1 = Enumerable.Repeat(CardIds.ArgentSquire, 30).ToList();
string hsClass0 = "hero_shaman";
Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
Decklist decklist1 = new Decklist(cardIdList1, hsClass0);
ConsoleActionReader actionGetter = new ConsoleActionReader();
PlayerDecisionMaker decisionMaker0 = new PlayerDecisionMaker(actionGetter);
PlayerDecisionMaker decisionMaker1 = new PlayerDecisionMaker(actionGetter);
TextUIManager textUIManager = new TextUIManager(new ConsoleTextLogger());

HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
    decklist0, decklist1, decisionMaker0, decisionMaker1, textUIManager
);
HearthstoneGame game = new HearthstoneGame(hsArgs);
game.SetupGame(false, false);
game.Players[0].AvailableMana = 10;
game.Players[1].AvailableMana = 10;
game.Play();