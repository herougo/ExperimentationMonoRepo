using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class Deathrattle : Trigger
    {
        public Deathrattle()
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _requiresSlotMatchForEvent = true;
        }

        public override Trigger Copy()
        {
            return new Deathrattle();
        }
    }
}
