using HearthstoneGameModel.Game;

namespace HearthstoneGameModel.UI
{
    public abstract class UIManager
    {
        protected HearthstoneGame _game = null;

        public virtual void SetGame(HearthstoneGame game) {
            _game = game;
        }

        public abstract void LogError(string message);

        public abstract void ReceiveUIEvent(UIEvent uiEvent);
    }
}
