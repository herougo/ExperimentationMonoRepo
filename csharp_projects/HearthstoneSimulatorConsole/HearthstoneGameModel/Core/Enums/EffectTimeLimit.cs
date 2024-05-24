using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public enum EffectTimeLimit : int
    {
        NoLimit = 0,
        EndOfTurn = 1,
        EndOfPlayerTurn = 2,
        EndOfOpponentTurn = 3
    }
}
