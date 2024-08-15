using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Heroes
{
    public class RogueDagger12 : WeaponCard
    {
        public RogueDagger12()
        {
            _cardId = "HU001";
            _name = "Rogue Dagger 1/2";
            _hsClass = HSClass.Rogue;
            _mana = 1;
            _collectible = false;

            _attack = 1;
            _durability = 2;
        }

        public override Card Copy()
        {
            return new RogueDagger12();
        }
    }

    public class SilverHandRecruit : MinionCard
    {
        public SilverHandRecruit() {
            _cardId = "HU002";
            _name = "Silver Hand Recruit";
            _hsClass = HSClass.Paladin;
            _mana = 1;
            _collectible = false;

            _attack = 1;
            _health = 1;
        }

        public override Card Copy()
        {
            return new SilverHandRecruit();
        }
    }

    public class SearingTotem : MinionCard
    {
        public SearingTotem()
        {
            _cardId = "HU003";
            _name = "Searing Totem";
            _hsClass = HSClass.Shaman;
            _mana = 1;
            _collectible = false;

            _attack = 1;
            _health = 1;
        }

        public override Card Copy()
        {
            return new SearingTotem();
        }
    }

    public class StoneclawTotem : MinionCard
    {
        public StoneclawTotem()
        {
            _cardId = "HU004";
            _name = "Stoneclaw Totem";
            _hsClass = HSClass.Shaman;
            _mana = 1;
            _collectible = false;

            _attack = 0;
            _health = 2;
            _inPlayEffects = new List<EMEffect>{ new Taunt() };
        }

        public override Card Copy()
        {
            return new StoneclawTotem();
        }
    }

    public class StrengthTotem : MinionCard
    {
        public StrengthTotem()
        {
            _cardId = "HU005";
            _name = "Strength Totem";
            _hsClass = HSClass.Shaman;
            _mana = 1;
            _collectible = false;

            _attack = 0;
            _health = 2;
            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new OnTurnEnd(),
                    new ChangeAttack(new RandomCharacterFrom(SelectionConstants.AllOtherFriendlyMinions), 1)
                )
            };
        }

        public override Card Copy()
        {
            return new StrengthTotem();
        }
    }

    public class HealingTotem : MinionCard
    {
        public HealingTotem()
        {
            _cardId = "HU006";
            _name = "Healing Totem";
            _hsClass = HSClass.Shaman;
            _mana = 1;
            _collectible = false;

            _attack = 0;
            _health = 2;
            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new OnTurnEnd(),
                    new Heal(SelectionConstants.AllFriendlyMinions, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new HealingTotem();
        }
    }

}
