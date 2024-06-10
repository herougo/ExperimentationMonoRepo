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

                case CardIds.Priest:
                    return new Priest();
                case CardIds.Rogue:
                    return new Rogue();
                case CardIds.Druid:
                    return new Druid();
                case CardIds.Shaman:
                    return new Shaman();
                case CardIds.Warlock:
                    return new Warlock();
                case CardIds.Paladin:
                    return new Paladin();
                case CardIds.Warrior:
                    return new Warrior();
                case CardIds.Hunter:
                    return new Hunter();
                case CardIds.Mage:
                    return new Mage();
                case CardIds.DemonHunter:
                    return new DemonHunter();

                case CardIds.RogueDagger12:
                    return new RogueDagger12();
                case CardIds.SilverHandRecruit:
                    return new SilverHandRecruit();
                case CardIds.SearingTotem:
                    return new SearingTotem();
                case CardIds.StoneclawTotem:
                    return new StoneclawTotem();
                case CardIds.StrengthTotem:
                    return new StrengthTotem();
                case CardIds.HealingTotem:
                    return new HealingTotem();

                case CardIds.Coin:
                    return new Coin();
                default:
                    throw new ArgumentException($"Unsupported cardId: {cardId}");
            }
        }
    }
}
