﻿using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class Battleboard
    {
        HearthstoneGame _game;

        public Battleboard(HearthstoneGame game)
        {
            _game = game;
        }

        public CardSlot GetSlot(int player, int boardIndex)
        {
            throw new NotImplementedException();
        }
    }
}