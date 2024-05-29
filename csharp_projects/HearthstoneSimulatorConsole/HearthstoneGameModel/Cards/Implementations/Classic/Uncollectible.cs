using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class DamagedGolem : MinionCard
    {
        public DamagedGolem()
        {
            _cardId = CardIds.DamagedGolem;
            _name = "Damaged Golem";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 2;
            _health = 1;
            _tag = MinionTag.Mech;
        }

        public override Card Copy()
        {
            return new DamagedGolem();
        }
    }
}
