﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utils;
using GameModel.Cards;
using GameModel.Cards.CardFactories;

namespace GameModel.Game.CardSlots
{
    public class CardSlot
    {
        protected int _hash;
        public Card Card;
        public int Player;
        public HearthstoneGame Game;

        public CardSlot(string cardId, int player, HearthstoneGame game) {
            _hash = HashGenerator.GetNextHash();
            Card = CardFactory.CreateCard(cardId);
            Player = player;
            Game = game;
        }
    }
}
