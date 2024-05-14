using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Utils;
using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Game.CardSlots
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

        public CardType CardType { get { return Card.CardType; } }
    }
}
