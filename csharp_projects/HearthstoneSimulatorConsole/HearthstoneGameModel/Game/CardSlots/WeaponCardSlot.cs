using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class WeaponCardSlot : CardSlot
    {
        WeaponCard TypedCard;

        // stats
        public int Attack;

        public int Durability;

        public WeaponCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            TypedCard = (WeaponCard)Card;
            Attack = TypedCard.Attack;
            Durability = TypedCard.Durability;
        }

        public override string ToString()
        {
            return $"CardSlot('{Card.Name}', Mana={Card.Mana}, {TypedCard.Attack} / {TypedCard.Durability})";
        }

        public override void UpdateStats()
        {
            int prevAttack = Attack;
            Attack = TypedCard.Attack;

            foreach (EffectManagerNode emNode in GetEMNodes())
            {
                emNode.Effect.AdjustStats(this);
            }

            Attack = Math.Max(0, Attack);

            if (prevAttack != Attack)
            {
                Game.EffectManager.SendEvent(new EffectEventArgs(EffectEvent.WeaponChangeStats, this));
            }
        }
    }
}
