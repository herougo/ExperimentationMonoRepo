using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.Metadata
{
    public class GameMetadata
    {
        public int WhoGoesFirst = 0;
        public int Turn = 0;
        public bool ReadyToEndTurn = false;

        // Temporarily used
        public int AttackerDamageTaken = 0;
        public int DefenderDamageTaken = 0;
    }
}
