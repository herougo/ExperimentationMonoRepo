using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.ValueMonitors
{
    public class BattleboardMinionsIntValueMonitor : IntValueMonitor
    {
        public BattleboardMinionsIntValueMonitor()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay, EffectEvent.CardMovedToHand
            };
        }

        public override IntValueMonitor Copy()
        {
            return new BattleboardMinionsIntValueMonitor();
        }
    }
}
