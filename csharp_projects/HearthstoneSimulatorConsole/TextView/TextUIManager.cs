using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.UI;
using TextView.UIEventHandling;

namespace TextView
{
    public class TextUIManager : UIManager
    {
        public TextUILogger TextUILogger;

        public TextUIManager(ITextLogger textLogger)
        {
            TextUILogger = new TextUILogger(textLogger);
        }

        public override void SetGame(HearthstoneGame game)
        {
            TextUILogger.SetGame(game);
            _game = game;
        }

        public override void LogError(string message)
        {
            TextUILogger.LogError(message);
        }

        public override void ReceiveUIEvent(UIEvent uiEvent)
        {
            UIEventHandler handler = UIEventHandlerFactory.GetHandler(uiEvent, this);
            handler.Handle(_game);
        }


    }
}
