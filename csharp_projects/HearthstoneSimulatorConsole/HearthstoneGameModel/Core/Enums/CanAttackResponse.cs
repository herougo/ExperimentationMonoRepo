using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public enum CanAttackResponse : int
    {
        Yes = 0,
        AttackedEnough = 1,
        Asleep = 2,
        DefenderHasStealth = 3,
        ZeroAttack = 4,
        DisobeysTaunt = 5,
        Frozen = 6,
        CantAttackEffect = 7
    }
}
