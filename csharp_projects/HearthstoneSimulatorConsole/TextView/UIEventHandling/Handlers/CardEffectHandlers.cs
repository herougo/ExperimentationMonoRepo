using HearthstoneGameModel.Game;
using HearthstoneGameModel.UI;
using HearthstoneGameModel.UI.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView.UIEventHandling.Handlers
{
    public class SecretRevealedUIEventHandler : UIEventHandler
    {
        SecretRevealedUIEvent _uiEvent;
        TextUIManager _textUiManager;

        public SecretRevealedUIEventHandler(
            SecretRevealedUIEvent uiEvent, TextUIManager textUIManager
        )
        {
            _uiEvent = uiEvent;
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogSecretRevealed(_uiEvent.CardName);
        }
    }
}
