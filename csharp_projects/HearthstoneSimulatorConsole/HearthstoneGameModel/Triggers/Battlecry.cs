using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class Battlecry : Trigger
    {
        public Battlecry()
        {
            _eventsReceived = new List<string> { EffectEvent.MinionBattlecry };
            _requiresSlotMatchForEvent = true;
        }

        public override Trigger Copy()
        {
            return new Battlecry();
        }
    }
}
