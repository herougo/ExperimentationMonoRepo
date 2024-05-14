using HearthstoneGameModel.Cards.CardTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class MinionCardSlot : DamageableCardSlot
    {
        // stats
        public int Mana;
        public int Attack;
        public int MaxHealth;
        public int Health;

        // managed by effects 
        // TODO

        // need to manage effectively
        public bool Silenced = false;
        public int AttacksThisTurn = 0;

        public MinionCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            MinionCard minionCard = (MinionCard)Card;
            Mana = minionCard.Mana;
            Attack = minionCard.Attack;
            MaxHealth = minionCard.Health;
            Health = minionCard.Health;
        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
        }
    }
}
