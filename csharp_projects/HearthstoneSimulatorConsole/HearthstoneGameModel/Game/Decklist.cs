using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class Decklist
    {
        public readonly List<string> CardIdList;
        public readonly string HeroClass; 

        public Decklist(List<string> cardIdList, string heroClass)
        {
            CardIdList = cardIdList;
            HeroClass = heroClass;
        }

        public bool IsValid()
        {
            return CardIdList.Count == HearthstoneConstants.DeckLength;
        }

        public Pile ToPile(int player, HearthstoneGame game)
        {
            List<CardSlot> cards = new List<CardSlot>();
            foreach (string cardId in CardIdList)
            {
                Card card = CardFactory.CreateCard(cardId);
                CardSlot cardSlot = card.CreateCardSlot(player, game);
                cards.Add(cardSlot);
            }
            return new Pile(cards);
        }
    }
}
