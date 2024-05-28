using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public abstract class MinionCard : Card
    {
        protected int _attack;
        protected int _health;
        protected MinionTag _tag = MinionTag.None;

        public int Attack { get { return _attack; } }
        public int Health { get { return _health; } }
        public MinionTag Tag { get { return _tag; } }

        public override CardType CardType { get { return CardType.Minion; } }

        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new MinionCardSlot(_cardId, player, game);
        }
    }
}
