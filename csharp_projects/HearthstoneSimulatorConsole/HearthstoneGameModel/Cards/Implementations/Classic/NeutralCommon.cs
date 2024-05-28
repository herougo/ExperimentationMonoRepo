using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class Wisp : MinionCard
    {
        public Wisp()
        {
            _cardId = CardIds.Wisp;
            _name = "Wisp";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 0;
            _attack = 1;
            _health = 1;
        }

        public override Card Copy()
        {
            return new Wisp();
        }
    }
}
