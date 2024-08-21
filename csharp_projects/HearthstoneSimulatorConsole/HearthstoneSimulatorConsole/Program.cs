using HearthstoneGameModel.Game;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Action;
using TextView;

// List<string> cardIdList0 = Enumerable.Repeat(CardIds.DreadCorsair, 30).ToList();
List<string> cardIdList0 = new List<string>
{
    CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
    CardIds.AngryChicken, CardIds.AngryChicken, CardIds.Snipe, CardIds.EaglehornBow
};
string hsClass0 = "hero_hunter";
Decklist decklist0 = new Decklist(cardIdList0, hsClass0);
Decklist decklist1 = new Decklist(cardIdList0, hsClass0);
ConsoleActionReader actionGetter = new ConsoleActionReader();
PlayerDecisionMaker decisionMaker0 = new PlayerDecisionMaker(actionGetter);
PlayerDecisionMaker decisionMaker1 = new PlayerDecisionMaker(actionGetter);
TextUIManager textUIManager = new TextUIManager(new ConsoleTextLogger());

HearthstoneGameArgs hsArgs = new HearthstoneGameArgs(
    decklist0, decklist1, decisionMaker0, decisionMaker1, textUIManager
);
HearthstoneGame game = new HearthstoneGame(hsArgs);
game.SetupGame(false, false);
game.PlayerMetadata[0].AvailableMana = 10;
game.PlayerMetadata[1].AvailableMana = 10;
game.Play();