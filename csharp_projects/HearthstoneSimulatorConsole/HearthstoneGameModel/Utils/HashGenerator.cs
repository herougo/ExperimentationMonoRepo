using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Utils
{
    public static class HashGenerator
    {
        static int HashCounter = 0;

        public static int GetNextHash()
        {
            int result = HashCounter;
            HashCounter++;
            return result;
        }
    }
}
