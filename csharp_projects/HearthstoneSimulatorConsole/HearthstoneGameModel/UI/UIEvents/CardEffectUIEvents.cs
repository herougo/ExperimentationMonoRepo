using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.UI.UIEvents
{
    public class SecretRevealedUIEvent : UIEvent
    {
        string _cardName;

        public SecretRevealedUIEvent(string cardName)
        {
            _cardName = cardName;
        }

        public string CardName { get { return _cardName; } }

        public override UIEventType EventType
        {
            get { return UIEventType.SecretRevealed; }
        }
    }
}
