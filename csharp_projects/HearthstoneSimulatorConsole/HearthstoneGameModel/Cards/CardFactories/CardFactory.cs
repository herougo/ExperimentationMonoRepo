using HearthstoneGameModel.Cards.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.Implementations.Classic;

namespace HearthstoneGameModel.Cards.CardFactories
{
    public static class CardFactory
    {
        public static Card CreateCard(string cardId)
        {
            Card result = null;
            switch (cardId)
            {
                case CardIds.Wisp:
                    result = new Wisp();
                    break;
            }
            return result;
        }
    }
}
