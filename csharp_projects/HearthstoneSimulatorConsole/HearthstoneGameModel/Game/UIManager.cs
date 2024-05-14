using HearthstoneGameModel.Game;

namespace HearthstoneGameModel.Game
{
    public abstract class UIManager
    {
        protected HearthstoneGame _game = null;

        public void SetGame(HearthstoneGame game) {
            _game = game;
        }

        public abstract void LogError(string message);

        public abstract void ReceiveUIEvent(string uiEvent);
    }
}
