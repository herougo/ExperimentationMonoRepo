using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Conditions;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class Wisp : MinionCard
    {
        public Wisp()
        {
            _cardId = CardIds.Wisp;
            _name = "Wisp";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 0;
            _attack = 1;
            _health = 1;
        }

        public override Card Copy()
        {
            return new Wisp();
        }
    }

    public class AbusiveSergeant : MinionCard
    {
        public AbusiveSergeant()
        {
            _cardId = CardIds.AbusiveSergeant;
            _name = "Abusive Sergeant";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new Battlecry(
                    new TimeLimitedOneTimeEffect(
                        new ChangeAttack(SelectionConstants.SelectOtherFriendlyMinion, 2),
                        EffectTimeLimit.EndOfTurn
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new AbusiveSergeant();
        }
    }

    public class ArgentSquire : MinionCard
    {
        public ArgentSquire()
        {
            _cardId = CardIds.ArgentSquire;
            _name = "Argent Squire";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new DivineShield()
            };
        }

        public override Card Copy()
        {
            return new ArgentSquire();
        }
    }

    public class LeperGnome : MinionCard
    {
        public LeperGnome()
        {
            _cardId = CardIds.LeperGnome;
            _name = "Leper Gnome";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 2;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new Deathrattle(new DealDamage(SelectionConstants.Opponent, 2))
            };
        }

        public override Card Copy()
        {
            return new LeperGnome();
        }
    }

    public class Sheildbearer : MinionCard
    {
        public Sheildbearer()
        {
            _cardId = CardIds.Sheildbearer;
            _name = "Sheildbearer";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 0;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new Taunt()
            };
        }

        public override Card Copy()
        {
            return new Sheildbearer();
        }
    }

    public class SouthseaDeckhand : MinionCard
    {
        public SouthseaDeckhand()
        {
            _cardId = CardIds.SouthseaDeckhand;
            _name = "Southsea Deckhand";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 2;
            _health = 1;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileWeaponEquipped(),
                    new Charge()
                )
            };
        }

        public override Card Copy()
        {
            return new SouthseaDeckhand();
        }
    }

    public class WorgenInfiltrator : MinionCard
    {
        public WorgenInfiltrator()
        {
            _cardId = CardIds.WorgenInfiltrator;
            _name = "Worgen Infiltrator";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 2;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new Stealth()
            };
        }

        public override Card Copy()
        {
            return new WorgenInfiltrator();
        }
    }

    public class YoungDragonhawk : MinionCard
    {
        public YoungDragonhawk()
        {
            _cardId = CardIds.YoungDragonhawk;
            _name = "Young Dragonhawk";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new Windfury()
            };
        }

        public override Card Copy()
        {
            return new YoungDragonhawk();
        }
    }

    public class AmaniBerserker : MinionCard
    {
        public AmaniBerserker()
        {
            _cardId = CardIds.AmaniBerserker;
            _name = "Amani Berserker";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 3;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new BuffAttack(3)
                )
            };
        }

        public override Card Copy()
        {
            return new AmaniBerserker();
        }
    }
}
