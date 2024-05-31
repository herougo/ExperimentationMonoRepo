using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;

namespace HearthstoneGameModel.Cards.CardTypes
{
    public abstract class HeroCard : Card
    {
        protected int _heroPowerCost;
        protected OneTimeEffect _heroPowerEffect;
        
        public int HeroPowerCost
        {
            get { return _heroPowerCost; }
        }

        public OneTimeEffect HeroPowerEffect
        {
            get { return _heroPowerEffect; }
        }

        public override CardType CardType { get { return CardType.Hero; } }
        public override CardSlot CreateCardSlot(int player, HearthstoneGame game)
        {
            return new HeroCardSlot(_cardId, player, game);
        }
    }
}
