using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public abstract class DamageableCardSlot : CardSlot
    {
        public DamageableCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game) { }
        public abstract void TakeDamage(int amount);
    }
}
