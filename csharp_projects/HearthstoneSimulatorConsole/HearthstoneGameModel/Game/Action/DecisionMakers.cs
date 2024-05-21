namespace HearthstoneGameModel.Game.Action
{
    public abstract class DecisionMaker
    {
        protected HearthstoneGame _game = null;

        public virtual void SetGame(HearthstoneGame game)
        {
            _game = game;
        }

        public abstract IAction GetAction();
    }
    public class PlayerDecisionMaker : DecisionMaker
    {
        IStringActionReader _actionReader;
        StringActionParser _actionParser = null;

        public PlayerDecisionMaker(IStringActionReader actionReader)
        {
            _actionReader = actionReader;
        }

        public override void SetGame(HearthstoneGame game)
        {
            _game = game;
            _actionParser = new StringActionParser(game);
        }

        public override IAction GetAction()
        {
            if (_game == null)
            {
                throw new System.Exception("Missing game");
            }
            string action = _actionReader.GetAction();
            return _actionParser.Parse(action);
        }
    }
}
