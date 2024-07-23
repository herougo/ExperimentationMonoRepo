using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.CardGeneration
{
    public class ConstantCardGenerator : ICardGenerator
    {
        Card _card;

        public ConstantCardGenerator(Card card)
        {
            _card = card;
        }

        public Card Generate(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            return _card.Copy();
        }

        public ICardGenerator Copy()
        {
            return new ConstantCardGenerator(_card.Copy());
        }
    }
}
