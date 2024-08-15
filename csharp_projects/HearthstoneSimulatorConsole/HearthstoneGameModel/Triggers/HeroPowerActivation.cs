using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class HeroPowerActivation : Trigger
    {
        public HeroPowerActivation() {
            _eventsReceived = new List<string> { EffectEvent.ActivateHeroPower };
            _requiresSlotMatchForEvent = true;
        }

        public override Trigger Copy()
        {
            return new HeroPowerActivation();
        }
    }
}
