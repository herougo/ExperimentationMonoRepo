using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public class WeaponCard : Card
    {
        protected int _mana;
        protected int _attack;
        protected int _durability;

        public int Mana { get { return _mana; } }
        public int Attack { get { return _attack; } }
        public int Durability { get { return _durability; } }

        public override CardType CardType { get { return CardType.Weapon; } }

        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new WeaponCardSlot(_cardId, player, game);
        }
    }
}
