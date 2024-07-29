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
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Effects.ContinuousEffects;

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

    public class Squire : MinionCard
    {
        public Squire()
        {
            _cardId = CardIds.Squire;
            _name = "Squire";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 2;
            _health = 2;
        }

        public override Card Copy()
        {
            return new Squire();
        }
    }

    public class Imp : MinionCard
    {
        public Imp()
        {
            _cardId = CardIds.Imp;
            _name = "Imp";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Demon;
        }

        public override Card Copy()
        {
            return new Imp();
        }
    }

    public class VioletApprentice : MinionCard
    {
        public VioletApprentice()
        {
            _cardId = CardIds.VioletApprentice;
            _name = "Violet Apprentice";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 1;
            _health = 1;
        }

        public override Card Copy()
        {
            return new VioletApprentice();
        }
    }

    public class Banana : SpellCard
    {
        public Banana()
        {
            _cardId = CardIds.Banana;
            _name = "Banana";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _whenPlayedEffect = new GiveEMEffect(
                new SelectCharacterFrom(SelectionConstants.AllMinions),
                new Buff(1, 1)
            );
        }

        public override Card Copy()
        {
            return new Banana();
        }
    }

    public class Squirrel : MinionCard
    {
        public Squirrel()
        {
            _cardId = CardIds.Squirrel;
            _name = "Squirrel";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Beast;
        }

        public override Card Copy()
        {
            return new Squirrel();
        }
    }

    public class Devilsaur : MinionCard
    {
        public Devilsaur()
        {
            _cardId = CardIds.Devilsaur;
            _name = "Devilsaur";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 5;
            _attack = 5;
            _health = 5;
            _tag = MinionTag.Beast;
        }

        public override Card Copy()
        {
            return new Devilsaur();
        }
    }

    public class BaineBloodhoof : MinionCard
    {
        public BaineBloodhoof()
        {
            _cardId = CardIds.BaineBloodhoof;
            _name = "Baine Bloodhoof";
            _hsClass = HeroClass.Neutral;
            _collectible = false;

            _mana = 5;
            _attack = 5;
            _health = 5;
        }

        public override Card Copy()
        {
            return new BaineBloodhoof();
        }
    }
}
