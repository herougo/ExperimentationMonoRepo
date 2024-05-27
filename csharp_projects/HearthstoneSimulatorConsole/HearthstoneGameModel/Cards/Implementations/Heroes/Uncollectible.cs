using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
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
                new OnTurnEnd(new ChangeAttack(SelectionConstants.RandomOtherFriendlyMinion, 1))
            };
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
                new OnTurnEnd(new Heal(SelectionConstants.AllFriendlyMinions, 1))
            };
        }
    }

}
