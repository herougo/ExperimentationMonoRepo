using HearthstoneGameModel.Cards.CardTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class MinionCardSlot : BattlerCardSlot
    {
        MinionCard TypedCard;

        // stats

        // managed by effects 
        // TODO


        public MinionCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            TypedCard = (MinionCard)Card;
            Attack = TypedCard.Attack;
            MaxHealth = TypedCard.Health;
            Health = TypedCard.Health;
        }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public override string ToString()
        {
            return $"CardSlot('{Card.Name}', Mana={Card.Mana}, {TypedCard.Attack} / {TypedCard.Health})";
        }
    }
}
