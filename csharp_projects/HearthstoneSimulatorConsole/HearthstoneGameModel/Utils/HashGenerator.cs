using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Utils
{
    public static class HashGenerator
    {
        public const int NullHash = -1;
        public const int Player0Hash = 0;
        public const int Player1Hash = 1;
        public static int LastHash = 1;

        public static int GetNextHash()
        {
            LastHash++;
            return LastHash;
        }
    }
}
