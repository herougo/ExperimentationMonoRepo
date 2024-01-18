using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel.Cards.CardTypes;
using GameModel.Cards.Enums;

namespace GameModel.Cards.Implementations.Classic
{
    public class Wisp : MinionCard
    {
        public Wisp()
        {
            _cardId = CardIds.Wisp;
            _name = "Wisp";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 0;
            _attack = 1;
            _health = 1;
        }

    }
}
