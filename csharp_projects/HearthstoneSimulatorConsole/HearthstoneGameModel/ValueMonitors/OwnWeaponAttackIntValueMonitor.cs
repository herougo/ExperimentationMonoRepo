using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.ValueMonitors
{
    public class OwnWeaponAttackIntValueMonitor : IntValueMonitor
    {
        public OwnWeaponAttackIntValueMonitor()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.WeaponDestroyed, EffectEvent.WeaponEquipped, EffectEvent.WeaponChangeStats
            };
        }

        public override IntValueMonitor Copy()
        {
            return new OwnWeaponAttackIntValueMonitor();
        }
    }
}
