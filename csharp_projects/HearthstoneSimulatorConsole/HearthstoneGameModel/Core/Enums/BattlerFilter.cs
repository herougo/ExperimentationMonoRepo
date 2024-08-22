using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public enum BattlerFilter : int
    {
        Any = 0,
        YourHero = 1,
        EnemyMinion = 2,
        YourMinion = 3
    }
}
