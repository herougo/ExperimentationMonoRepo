using HearthstoneGameModel.Game.Actions;

namespace HearthstoneGameModel.Game
{
    public class DecisionMaker
    {
        public IActionGetter ActionGetter;
        HearthstoneGame _game = null;

        public DecisionMaker(IActionGetter actionGetter)
        {
            ActionGetter = actionGetter;
        }

        public void SetGame(HearthstoneGame game)
        {
            _game = game;
        }

        // TODO: more DecisionMaker stuff
    }
}
