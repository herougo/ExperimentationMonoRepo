using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public enum AddSecretResult : int
    {
        Success = 0,
        DuplicateSecret = 1,
        Full = 2
    }
}
