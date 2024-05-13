using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.Enums;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public class MinionCard : Card
    {
        protected int _mana;
        protected int _attack;
        protected int _health;

        public int Mana { get { return _mana; } }
        public int Attack { get { return _attack; } }
        public int Health { get { return _health; } }

        public CardType CardType { get { return CardType.Minion; } }
    }
}
