using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Heroes
{
    public class Paladin : HeroCard
    {
        public Paladin() {
            _cardId = "hero_paladin";
            _name = "Paladin";
            _hsClass = HSClass.Paladin;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new SummonMinion(new SilverHandRecruit());
        }
    }
}
