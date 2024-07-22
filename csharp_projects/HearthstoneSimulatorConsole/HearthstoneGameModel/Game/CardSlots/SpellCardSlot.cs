using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class SpellCardSlot : CardSlot
    {
        public SpellCard TypedCard;

        public SpellCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            TypedCard = (SpellCard)Card;
        }

        public override void UpdateStats()
        {
            Mana = TypedCard.Mana;

            foreach (EffectManagerNode emNode in GetEMNodes())
            {
                emNode.Effect.AdjustStats(this);
            }

            Mana = Math.Max(0, Mana);
        }

        public override string ToString()
        {
            return $"CardSlot('{Card.Name}', Mana={Mana})";
        }
    }
}
