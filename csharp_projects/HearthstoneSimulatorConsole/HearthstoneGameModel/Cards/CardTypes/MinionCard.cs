﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;

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

        public override CardType CardType { get { return CardType.Minion; } }

        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new MinionCardSlot(_cardId, player, game);
        }
    }
}