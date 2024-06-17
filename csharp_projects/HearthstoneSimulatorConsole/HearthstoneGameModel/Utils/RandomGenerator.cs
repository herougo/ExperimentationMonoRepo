using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Utils
{
    public static class RandomGenerator
    {
        static int _seed = 0;
        static Random _random = new Random(0);

        public static int GetRandomInt(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue+1);
        }

        public static void SetSeed(int seed)
        {
            _seed = seed;
            _random = new Random(seed);
        }
    }
}
