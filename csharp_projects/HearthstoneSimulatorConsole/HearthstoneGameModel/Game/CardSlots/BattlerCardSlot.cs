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

        public BattlerCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) { }
        public abstract void TakeDamage(int amount);
    }
}
