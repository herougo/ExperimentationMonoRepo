using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SelectionFilters;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class ExplosiveTrap : SpellCard
    {
        public ExplosiveTrap()
        {
            _cardId = CardIds.ExplosiveTrap;
            _name = "Explosive Trap";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _spellType = SpellType.Secret;
            _school = SpellSchool.Fire;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.Any, BattlerFilter.YourHero),
                new DealDamage(SelectionConstants.OtherLivingEnemies, 2)
            );
        }

        public override Card Copy()
        {
            return new ExplosiveTrap();
        }
    }

    public class FreezingTrap : SpellCard
    {
        public FreezingTrap()
        {
            _cardId = CardIds.FreezingTrap;
            _name = "Freezing Trap";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _spellType = SpellType.Secret;
            _school = SpellSchool.Frost;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.EnemyMinion, BattlerFilter.Any),
                new ReturnMinionToHandAndChangeMana(
                    SelectionConstants.EventSlot0, 2
                )
            );
        }

        public override Card Copy()
        {
            return new FreezingTrap();
        }
    }

    public class Snipe : SpellCard
    {
        public Snipe()
        {
            _cardId = CardIds.Snipe;
            _name = "Snipe";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _spellType = SpellType.Secret;

            _whenPlayedEffect = new CreateSecret(
                new WhenOpponentPlaysLivingMinion(),
                new DealDamage(SelectionConstants.EventSlot0, 4)
            );
        }

        public override Card Copy()
        {
            return new Snipe();
        }
    }

    public class ScavengingHyena : MinionCard
    {
        public ScavengingHyena()
        {
            _cardId = CardIds.ScavengingHyena;
            _name = "Scavenging Hyena";
            _hsClass = HSClass.Hunter;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 2;

            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new WhenOtherMinionDies(PlayerChoice.Player, MinionTag.Beast),
                    new GiveEMEffect(SelectionConstants.OwnSelf, new Buff(2, 1))
                )
            };
        }

        public override Card Copy()
        {
            return new ScavengingHyena();
        }
    }

    public class DeadlyShot : SpellCard
    {
        public DeadlyShot()
        {
            _cardId = CardIds.DeadlyShot;
            _name = "Deadly Shot";
            _hsClass = HSClass.Hunter;
            _mana = 3;
            _collectible = true;

            _whenPlayedEffect = new DestroyMinion(
                new RandomCharacterFrom(SelectionConstants.OtherLivingEnemyMinions)
            );
        }

        public override Card Copy()
        {
            return new DeadlyShot();
        }
    }

    public class UnleashTheHounds : SpellCard
    {
        public UnleashTheHounds()
        {
            _cardId = CardIds.UnleashTheHounds;
            _name = "Unleash the Hounds";
            _hsClass = HSClass.Hunter;
            _mana = 3;
            _collectible = true;

            _whenPlayedEffect = new NEffects(
                new SummonMinion(new Hound()),
                new BattleboardMinionsIntValue(PlayerChoice.Opponent)
            );
        }

        public override Card Copy()
        {
            return new UnleashTheHounds();
        }
    }

    public class Flare : SpellCard
    {
        public Flare()
        {
            _cardId = CardIds.Flare;
            _name = "Flare";
            _hsClass = HSClass.Hunter;
            _mana = 1;
            _collectible = true;

            _whenPlayedEffect = new OneTimeEffectSequence(new List<OneTimeEffect>
            {
                new LoseEMEffect(SelectionConstants.AllMinions, EMEffectType.Stealth),
                new DestroyAllSecrets(PlayerChoice.Opponent),
                new DrawCards(SelectionConstants.Player, 1)
            });
        }

        public override Card Copy()
        {
            return new Flare();
        }
    }

    public class EaglehornBow : WeaponCard
    {
        public EaglehornBow()
        {
            _cardId = CardIds.EaglehornBow;
            _name = "Eaglehorn Bow";
            _hsClass = HSClass.Hunter;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _durability = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new WhenSecretRevealed(PlayerChoice.Player),
                    new GainWeaponDurability(1, false)
                )
            };
        }

        public override Card Copy()
        {
            return new EaglehornBow();
        }
    }

    public class ExplosiveShot : SpellCard
    {
        public ExplosiveShot()
        {
            _cardId = CardIds.ExplosiveShot;
            _name = "Explosive Shot";
            _hsClass = HSClass.Hunter;
            _mana = 5;
            _collectible = true;

            _school = SpellSchool.Fire;

            _whenPlayedEffect = new OneTimeEffectSequence(new List<OneTimeEffect>
            {
                new DealDamageToAdjacentMinions(
                    new SelectCharacterFrom(SelectionConstants.AllMinions), 2, 5, 2
                )
            });
        }

        public override Card Copy()
        {
            return new ExplosiveShot();
        }
    }



    public class SavannahHighmane : MinionCard
    {
        public SavannahHighmane()
        {
            _cardId = CardIds.SavannahHighmane;
            _name = "Savannah Highmane";
            _hsClass = HSClass.Hunter;
            _collectible = true;

            _mana = 6;
            _attack = 7;
            _health = 5;

            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Deathrattle(),
                    new NEffects(new SummonMinion(new Hyena()), 2)
                )
            };
        }

        public override Card Copy()
        {
            return new SavannahHighmane();
        }
    }

    public class BestialWrath : SpellCard
    {
        public BestialWrath()
        {
            _cardId = CardIds.BestialWrath;
            _name = "Bestial Wrath";
            _hsClass = HSClass.Hunter;
            _mana = 1;
            _collectible = true;

            _whenPlayedEffect = new GiveEMEffect(
                new SelectCharacterFrom(
                    SelectionConstants.AllOtherFriendlyMinions & new TagSelectionFilter(MinionTag.Beast)
                ),
                new List<EMEffect> { 
                    new TimeLimitedEMEffect(new BuffAttack(2), EffectTimeLimit.EndOfTurn),
                    new TimeLimitedEMEffect(new Immune(), EffectTimeLimit.EndOfTurn)
                }
            );  
        }

        public override Card Copy()
        {
            return new BestialWrath();
        }
    }

    public class SnakeTrap : SpellCard
    {
        public SnakeTrap()
        {
            _cardId = CardIds.SnakeTrap;
            _name = "Snake Trap";
            _hsClass = HSClass.Hunter;
            _mana = 2;
            _collectible = true;

            _spellType = SpellType.Secret;

            _whenPlayedEffect = new CreateSecret(
                new WhenAttackDeclared(BattlerFilter.Any, BattlerFilter.YourMinion),
                new NEffects(new SummonMinion(new Snake()), 3)
            );
        }

        public override Card Copy()
        {
            return new SnakeTrap();
        }
    }
}
