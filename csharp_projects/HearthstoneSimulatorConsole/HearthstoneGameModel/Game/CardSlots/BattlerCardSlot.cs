using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public abstract class BattlerCardSlot : CardSlot
    {
        public int Attack = 0;
        public int AttacksThisTurn = 0;

        public bool HasSleep = false;
        public int NumFrozen = 0;
        public int NumWindfury = 0;
        public int NumCharge = 0;
        public int NumStealth = 0;

        public BattlerCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) { }
        public abstract void TakeDamage(int amount);

        public bool IsFrozen
        {
            get { return NumFrozen > 0; }
        }

        public bool HasWindfury
        {
            get { return NumWindfury > 0; }
        }

        public bool HasCharge
        {
            get { return NumCharge > 0; }
        }

        public bool HasStealth
        {
            get { return NumStealth > 0; }
        }

        public int NumPossibleAttacksIgnoringFrozen
        {
            get
            {
                if (HasSleep)
                {
                    return 0;
                }
                else if (HasWindfury)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
