using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Selections.SelectionFilters;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class DamagedGolem : MinionCard
    {
        public DamagedGolem()
        {
            _cardId = CardIds.DamagedGolem;
            _name = "Damaged Golem";
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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

    public class Gnoll : MinionCard
    {
        public Gnoll()
        {
            _cardId = CardIds.Gnoll;
            _name = "Gnoll";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 2;
            _attack = 2;
            _health = 2;

            _inPlayEffects = new List<EMEffect> { new Taunt() };
        }

        public override Card Copy()
        {
            return new Gnoll();
        }
    }

    public class PipQuickwit : MinionCard
    {
        public PipQuickwit()
        {
            _cardId = CardIds.PipQuickwit;
            _name = "Pip Quickwit";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 3;
            _attack = 3;
            _health = 3;
        }

        public override Card Copy()
        {
            return new PipQuickwit();
        }
    }

    public class XavianSatyr : MinionCard
    {
        public XavianSatyr()
        {
            _cardId = CardIds.XavianSatyr;
            _name = "Xavian Satyr";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 2;
            _health = 1;

            _tag = MinionTag.Demon;
        }

        public override Card Copy()
        {
            return new XavianSatyr();
        }
    }

    public class Whelp : MinionCard
    {
        public Whelp()
        {
            _cardId = CardIds.Whelp;
            _name = "Whelp";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 1;
            _attack = 1;
            _health = 1;

            _tag = MinionTag.Dragon;
        }

        public override Card Copy()
        {
            return new Whelp();
        }
    }

    public class Dream : SpellCard
    {
        public Dream()
        {
            _cardId = CardIds.Dream;
            _name = "Dream";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 0;
            _school = SpellSchool.Nature;

            _whenPlayedEffect = new ReturnMinionToHand(new SelectCharacterFrom(
                SelectionConstants.AllMinions
            ));
        }

        public override Card Copy()
        {
            return new Dream();
        }
    }

    public class Nightmare : SpellCard
    {
        public Nightmare()
        {
            _cardId = CardIds.Nightmare;
            _name = "Nightmare";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 0;
            _school = SpellSchool.Shadow;

            _whenPlayedEffect = new GiveEMEffect(
                new SelectCharacterFrom(SelectionConstants.AllMinions),
                new List<EMEffect> {
                    new Buff(5, 5),
                    new TriggerEffect(
                        new OnTurnStart(PlayerChoice.Player),
                        new DestroyMinion(SelectionConstants.OwnSelf)
                    )
                }
            );
        }

        public override Card Copy()
        {
            return new Nightmare();
        }
    }

    public class LaughingSister : MinionCard
    {
        public LaughingSister()
        {
            _cardId = CardIds.LaughingSister;
            _name = "Laughing Sister";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 2;
            _attack = 3;
            _health = 5;

            _inPlayEffects = new List<EMEffect> { new Elusive() };
        }

        public override Card Copy()
        {
            return new LaughingSister();
        }
    }

    public class YseraAwakens : SpellCard
    {
        public YseraAwakens()
        {
            _cardId = CardIds.YseraAwakens;
            _name = "Ysera Awakens";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 2;
            _school = SpellSchool.Nature;

            _whenPlayedEffect = new DealDamage(
                SelectionConstants.AllCharacters & new NotNamedYseraFilter(),
                5
            );
        }

        public override Card Copy()
        {
            return new Nightmare();
        }
    }

    public class EmeraldDrake : MinionCard
    {
        public EmeraldDrake()
        {
            _cardId = CardIds.EmeraldDrake;
            _name = "Emerald Drake";
            _hsClass = HSClass.Neutral;
            _collectible = false;

            _mana = 4;
            _attack = 7;
            _health = 6;

            _tag = MinionTag.Dragon;
        }

        public override Card Copy()
        {
            return new EmeraldDrake();
        }
    }

    public class Panther : MinionCard
    {
        public Panther()
        {
            _cardId = CardIds.Panther;
            _name = "Panther";
            _hsClass = HSClass.Druid;
            _collectible = false;

            _mana = 2;
            _attack = 3;
            _health = 2;
            _tag = MinionTag.Beast;
        }

        public override Card Copy()
        {
            return new Panther();
        }
    }

    public class TreantClassic : MinionCard
    {
        public TreantClassic()
        {
            _cardId = CardIds.TreantClassic;
            _name = "Treant";
            _hsClass = HSClass.Druid;
            _collectible = false;

            _mana = 1;
            _attack = 2;
            _health = 2;
        }

        public override Card Copy()
        {
            return new TreantClassic();
        }
    }

    public class DruidOfTheClawBearForm : MinionCard
    {
        public DruidOfTheClawBearForm()
        {
            _cardId = CardIds.DruidOfTheClawBearForm;
            _name = "Druid of the Claw";
            _hsClass = HSClass.Druid;
            _collectible = false;

            _mana = 6;
            _attack = 4;
            _health = 9;

            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> { new Taunt() };
        }

        public override Card Copy()
        {
            return new DruidOfTheClawBearForm();
        }
    }

    public class DruidOfTheClawCatForm : MinionCard
    {
        public DruidOfTheClawCatForm()
        {
            _cardId = CardIds.DruidOfTheClawCatForm;
            _name = "Druid of the Claw";
            _hsClass = HSClass.Druid;
            _collectible = false;

            _mana = 6;
            _attack = 7;
            _health = 6;

            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> { new Rush() };
        }

        public override Card Copy()
        {
            return new DruidOfTheClawCatForm();
        }
    }

    public class TreantClassicTaunt : MinionCard
    {
        public TreantClassicTaunt()
        {
            _cardId = CardIds.TreantClassicTaunt;
            _name = "Treant";
            _hsClass = HSClass.Druid;
            _collectible = false;

            _mana = 1;
            _attack = 2;
            _health = 2;

            _inPlayEffects = new List<EMEffect> { new Taunt() };
        }

        public override Card Copy()
        {
            return new TreantClassicTaunt();
        }
    }
}
