using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public class OriginalHeroCard : Card
    {
        protected int _heroPowerCost;
        // TODO: protected ???? _heroPowerEffect;
        // TODO: effects

        public override CardType CardType { get { return CardType.Hero; } }
        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new HeroCardSlot(_cardId, player, game);
        }
    }
}
