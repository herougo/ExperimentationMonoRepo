using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Cards.Implementations.Heroes;
using HearthstoneGameModel.Cards.Implementations;

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

                case CardIds.Shieldbearer:
                    return new Shieldbearer();

                case CardIds.YoungDragonhawk:
                    return new YoungDragonhawk();

                case CardIds.StranglethornTiger:
                    return new StranglethornTiger();

                case CardIds.FrostElemental:
                    return new FrostElemental();

                case CardIds.ArgentCommander:
                    return new ArgentCommander();

                case CardIds.Paladin:
                    return new Paladin();
                case CardIds.SilverHandRecruit:
                    return new SilverHandRecruit();
                case CardIds.Coin:
                    return new Coin();
                default:
                    throw new ArgumentException("Unsupported cardId");
            }
        }
    }
}
