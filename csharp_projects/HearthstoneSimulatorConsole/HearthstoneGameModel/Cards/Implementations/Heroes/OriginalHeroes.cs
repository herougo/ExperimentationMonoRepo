using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Heroes
{
    public class Priest : HeroCard
    {
        public Priest() {
            _cardId = "hero_priest";
            _name = "Priest";
            _hsClass = HSClass.Priest;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new Heal(SelectionConstants.SelectCharacter, 2);
        }

        public override Card Copy()
        {
            return new Priest();
        }
    }

    public class Rogue : HeroCard
    {
        public Rogue()
        {
            _cardId = "hero_rogue";
            _name = "Rogue";
            _hsClass = HSClass.Rogue;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new EquipWeapon(SelectionConstants.Player, new RogueDagger12());
        }

        public override Card Copy()
        {
            return new Rogue();
        }
    }

    public class Druid : HeroCard
    {
        public Druid()
        {
            _cardId = "hero_druid";
            _name = "Druid";
            _hsClass = HSClass.Druid;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new OneTimeEffectSequence(
                new List<OneTimeEffect> {
                    new GainArmour(SelectionConstants.Player, 1),
                    new TimeLimitedOneTimeEffect(
                        new ChangeAttack(SelectionConstants.Player, 1),
                        EffectTimeLimit.EndOfTurn
                    )
                }
            );
        }

        public override Card Copy()
        {
            return new Druid();
        }
    }

    public class Shaman : HeroCard
    {
        public Shaman()
        {
            _cardId = "hero_shaman";
            _name = "Shaman";
            _hsClass = HSClass.Shaman;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new SummonMinionLikeShamanHP(
                new List<MinionCard> {
                    new SearingTotem(), new HealingTotem(), new StoneclawTotem(), new StrengthTotem()
                }
            );
        }

        public override Card Copy()
        {
            return new Shaman();
        }
    }

    public class Warlock : HeroCard
    {
        public Warlock()
        {
            _cardId = "hero_warlock";
            _name = "Warlock";
            _hsClass = HSClass.Warlock;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new OneTimeEffectSequence(
                new List<OneTimeEffect>
                {
                    new DealDamage(SelectionConstants.Player, 2),
                    new DrawCards(SelectionConstants.Player, 1),
                }
            );
        }

        public override Card Copy()
        {
            return new Warlock();
        }
    }

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

        public override Card Copy()
        {
            return new Paladin();
        }
    }

    public class Warrior : HeroCard
    {
        public Warrior()
        {
            _cardId = "hero_warrior";
            _name = "Warrior";
            _hsClass = HSClass.Warrior;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new GainArmour(SelectionConstants.Player, 2);
        }

        public override Card Copy()
        {
            return new Warrior();
        }
    }

    public class Hunter : HeroCard
    {
        public Hunter()
        {
            _cardId = "hero_hunter";
            _name = "Hunter";
            _hsClass = HSClass.Hunter;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new DealDamage(SelectionConstants.Opponent, 2);
        }

        public override Card Copy()
        {
            return new Hunter();
        }
    }

    public class Mage : HeroCard
    {
        public Mage()
        {
            _cardId = "hero_mage";
            _name = "Mage";
            _hsClass = HSClass.Mage;
            _mana = 0;
            _heroPowerCost = 2;
            _heroPowerEffect = new DealDamage(SelectionConstants.SelectCharacter, 1);
        }

        public override Card Copy()
        {
            return new Mage();
        }
    }

    public class DemonHunter : HeroCard
    {
        public DemonHunter()
        {
            _cardId = "hero_demon_hunter";
            _name = "Demon Hunter";
            _hsClass = HSClass.DemonHunter;
            _mana = 0;
            _heroPowerCost = 1;
            _heroPowerEffect = new TimeLimitedOneTimeEffect(
                new ChangeAttack(SelectionConstants.Player, 1),
                EffectTimeLimit.EndOfTurn
            );
        }

        public override Card Copy()
        {
            return new DemonHunter();
        }
    }
}
