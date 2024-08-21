using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.Metadata
{
    public class PlayerMetadata
    {
        public int HandLimit = HearthstoneConstants.HandLimit;
        public int BattleboardLimit = HearthstoneConstants.BattleboardLimit;

        public int SpellDamage = 0;

        public int CurrentMana = 0; // CurrentMana / AvailableMana
        public int AvailableMana = 0;
        public int MaximumMana = 0;
        public int Armour = 0;
        public bool HeroPowerUsedThisTurn = false;

        // Turn Metadata
        public int MinionPlayCount = 0;
    }
}
