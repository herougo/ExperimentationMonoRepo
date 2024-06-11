using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            Mana = TypedCard.Mana;
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
            return $"CardSlot('{Card.Name}', Mana={Mana}, {Attack} / {Health})";
        }

        public override void UpdateStats()
        {
            Mana = TypedCard.Mana;
            Attack = TypedCard.Attack;
            int prevMaxHealth = MaxHealth;
            MaxHealth = TypedCard.Health;
            int prevHealth = Health;
            
            foreach (EffectManagerNode emNode in GetEMNodes())
            {
                emNode.Effect.AdjustStats(this);
            }

            Mana = Math.Max(0, Mana);
            Attack = Math.Max(0, Attack);

            int newHealth = Math.Min(
                prevHealth + Math.Max(0, MaxHealth - prevMaxHealth),
                MaxHealth
            );
            Health = newHealth;


            /* Cases                   prevHealth  Health   MaxHealth  prevMaxHealth  newHealth
               * silenced health buff:   4           3        3          4              3
               * damaged & silenced:     1           1        3          4              1
               * buffed:                 3           4        4          3              4
               * damaged & buffed:       2           3        4          3              3
               * damaged, existing buff: 3           4        4          4              3
             */
        }
    }
}
