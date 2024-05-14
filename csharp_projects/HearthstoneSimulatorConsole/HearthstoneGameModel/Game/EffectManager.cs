using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class EffectManager
    {
        HearthstoneGame _game;

        public EffectManager(HearthstoneGame game) {
            _game = game;
        }

        public void SendEvent(string effectEvent, CardSlot eventSlot)
        {
            throw new NotImplementedException();
        }

        public void SendEvent(string effectEvent)
        {
            SendEvent(effectEvent, null);
        }
    }
}
