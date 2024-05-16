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
        public int _originalMana;

        public CardSlot(string cardId, int player, HearthstoneGame game) {
            _hash = HashGenerator.GetNextHash();
            Card = CardFactory.CreateCard(cardId);
            Player = player;
            Game = game;
            _originalMana = Card.Mana;
        }

        public int Hash { get { return _hash; } }

        public override int GetHashCode() { return Hash; }

        public int Mana { get { return _originalMana; } }

        public CardType CardType { get { return Card.CardType; } }

        public void UpdateStats()
        {
            // TODO: implement
        }
    }
}
