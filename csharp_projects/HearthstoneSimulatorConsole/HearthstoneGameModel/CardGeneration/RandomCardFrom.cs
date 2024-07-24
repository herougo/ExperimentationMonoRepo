using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using HearthstoneGameModel.Utils;

namespace HearthstoneGameModel.CardGeneration
{
    public class RandomCardFrom : ICardGenerator
    {
        List<Card> _options;

        public RandomCardFrom(List<Card> options) {
            _options = options;
        }

        public Card Generate(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            int choice = RandomGenerator.GetRandomInt(0, _options.Count - 1);
            return _options[choice].Copy();
        }

        public ICardGenerator Copy()
        {
            List<Card> optionsCopy = new List<Card>();
            foreach (Card card in _options)
            {
                optionsCopy.Add(card.Copy());
            }
            return new RandomCardFrom(optionsCopy);
        }
    }
}
