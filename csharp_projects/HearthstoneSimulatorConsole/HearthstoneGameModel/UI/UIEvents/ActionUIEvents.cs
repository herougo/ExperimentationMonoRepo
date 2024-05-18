using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.UI.UIEvents
{
    public class ActionCompletedUIEvent : UIEvent
    {
        public override UIEventType EventType
        {
            get { return UIEventType.ActionCompleted; }
        }
    }
}
