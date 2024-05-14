using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Cards.CardTypes;
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
        public int Attack;
        public int Durability;

        public WeaponCardSlot(string cardId, int player, HearthstoneGame game)
            : base(cardId, player, game)
        {
            WeaponCard weaponCard = (WeaponCard)Card;
            Attack = weaponCard.Attack;
            Durability = weaponCard.Durability;
        }
    }
}
