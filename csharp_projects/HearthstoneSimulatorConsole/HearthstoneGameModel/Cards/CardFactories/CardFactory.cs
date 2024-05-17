using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Cards.Implementations.Heroes;

namespace HearthstoneGameModel.Cards.CardFactories
{
    public static class CardFactory
    {
        public static Card CreateCard(string cardId)
        {
            switch (cardId)
            {
                case CardIds.Wisp:
                    return new Wisp();
                case CardIds.Paladin:
                    return new Paladin();
                case CardIds.SilverHandRecruit:
                    return new SilverHandRecruit();
                default:
                    throw new ArgumentException("Unsupported cardId");
            }
        }
    }
}
