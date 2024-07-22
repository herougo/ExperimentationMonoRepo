using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class BloodmageThalnos : MinionCard
    {
        public BloodmageThalnos()
        {
            _cardId = CardIds.BloodmageThalnos;
            _name = "Bloodmage Thalnos";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect>
            {
                new SpellDamage(1), new Deathrattle(new DrawCards(SelectionConstants.Player, 1))
            };
        }

        public override Card Copy()
        {
            return new BloodmageThalnos();
        }
    }
}
