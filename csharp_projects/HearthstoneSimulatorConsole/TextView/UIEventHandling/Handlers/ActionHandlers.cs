using HearthstoneGameModel.Game;
using HearthstoneGameModel.UI.UIEvents;
using HearthstoneGameModel.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView.UIEventHandling.Handlers
{
    public class ActionCompletedUIEventHandler : UIEventHandler
    {
        TextUIManager _textUiManager;

        public ActionCompletedUIEventHandler(
            TextUIManager textUIManager
        )
        {
            _textUiManager = textUIManager;
        }

        public override void Handle(HearthstoneGame game)
        {
            _textUiManager.TextUILogger.LogGameState();
        }
    }
}
