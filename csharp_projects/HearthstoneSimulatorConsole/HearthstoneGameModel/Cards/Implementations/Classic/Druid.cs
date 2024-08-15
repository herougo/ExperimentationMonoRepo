using HearthstoneGameModel.CardGeneration;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{

    public class PowerOfTheWild : SpellCard
    {
        public PowerOfTheWild()
        {
            _cardId = CardIds.PowerOfTheWild;
            _name = "Power of the Wild";
            _hsClass = HSClass.Druid;
            _mana = 2;
            _collectible = true;

            _whenPlayedEffect = new ChooseOne(
                new GiveEMEffect(SelectionConstants.AllFriendlyMinions, new Buff(1, 1)),
                new SummonMinion(new Panther())
            );
        }

        public override Card Copy()
        {
            return new PowerOfTheWild();
        }
    }

    public class Wrath : SpellCard
    {
        public Wrath()
        {
            _cardId = CardIds.Wrath;
            _name = "Wrath";
            _hsClass = HSClass.Druid;
            _mana = 2;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new ChooseOne(
                new DealDamage(new SelectCharacterFrom(SelectionConstants.AllMinions), 3),
                new OneTimeEffectSequence(new List<OneTimeEffect> { 
                    new DealDamage(new SelectCharacterFrom(SelectionConstants.AllMinions), 1),
                    new DrawCards(SelectionConstants.Player, 1)
                })
            );
        }

        public override Card Copy()
        {
            return new PowerOfTheWild();
        }
    }

    public class MarkOfNature : SpellCard
    {
        public MarkOfNature()
        {
            _cardId = CardIds.MarkOfNature;
            _name = "Mark of Nature";
            _hsClass = HSClass.Druid;
            _mana = 3;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new ChooseOne(
                new ChangeAttack(new SelectCharacterFrom(SelectionConstants.AllMinions), 4),
                new GiveEMEffect(
                    new SelectCharacterFrom(SelectionConstants.AllMinions),
                    new List<EMEffect>
                    {
                        new BuffHealth(4), new Taunt()
                    }
                )
            );
        }

        public override Card Copy()
        {
            return new MarkOfNature();
        }
    }

    public class SoulOfTheForest : SpellCard
    {
        public SoulOfTheForest()
        {
            _cardId = CardIds.SoulOfTheForest;
            _name = "Soul of the Forest";
            _hsClass = HSClass.Druid;
            _mana = 3;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new GiveEMEffect(
                SelectionConstants.AllFriendlyMinions,
                new TriggerEffect(
                    new Deathrattle(),
                    new SummonMinion(new TreantClassic())
                )
            );
        }

        public override Card Copy()
        {
            return new SoulOfTheForest();
        }
    }

    public class DruidOfTheClaw : MinionCard
    {
        public DruidOfTheClaw()
        {
            _cardId = CardIds.DruidOfTheClaw;
            _name = "Druid of the Claw";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 4;
            _health = 6;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new ChooseOneTrigger(),
                    new ChooseOne(new List<OneTimeEffect> {
                        new TransformInPlayMinion(
                            SelectionConstants.OwnSelf,
                            new ConstantCardGenerator(new DruidOfTheClawCatForm())),
                        new TransformInPlayMinion(
                            SelectionConstants.OwnSelf,
                            new ConstantCardGenerator(new DruidOfTheClawBearForm()))
                    })
                )
            };
        }

        public override Card Copy()
        {
            return new DruidOfTheClaw();
        }
    }

    public class GiftOfTheWild : SpellCard
    {
        public GiftOfTheWild()
        {
            _cardId = CardIds.GiftOfTheWild;
            _name = "Gift of the Wild";
            _hsClass = HSClass.Druid;
            _mana = 8;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new GiveEMEffect(
                SelectionConstants.AllFriendlyMinions,
                new List<EMEffect> { new Buff(2, 2), new Taunt() }
            );
        }

        public override Card Copy()
        {
            return new GiftOfTheWild();
        }
    }

    public class Savagery : SpellCard
    {
        public Savagery()
        {
            _cardId = CardIds.Savagery;
            _name = "Savagery";
            _hsClass = HSClass.Druid;
            _mana = 1;
            _collectible = true;

            _whenPlayedEffect = new DealDamage(
                new SelectCharacterFrom(SelectionConstants.AllMinions),
                new PlayerAttackIntValue()
            );
        }

        public override Card Copy()
        {
            return new Savagery();
        }
    }

    public class Bite : SpellCard
    {
        public Bite()
        {
            _cardId = CardIds.Bite;
            _name = "Bite";
            _hsClass = HSClass.Druid;
            _mana = 4;
            _collectible = true;

            _whenPlayedEffect = new OneTimeEffectSequence(new List<OneTimeEffect> {
                new TimeLimitedOneTimeEffect(
                    new ChangeAttack(SelectionConstants.Player, 4),
                    EffectTimeLimit.EndOfTurn
                ),
                new GainArmour(SelectionConstants.Player, 4)
            });
        }

        public override Card Copy()
        {
            return new Bite();
        }
    }

    public class KeeperOfTheGrove : MinionCard
    {
        public KeeperOfTheGrove()
        {
            _cardId = CardIds.KeeperOfTheGrove;
            _name = "Keeper of the Grove";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 2;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new ChooseOneTrigger(),
                    new ChooseOne(new List<OneTimeEffect> {
                        new DealDamage(new SelectCharacterFrom(SelectionConstants.AllCharacters), 2),
                        new Silence(new SelectCharacterFrom(SelectionConstants.AllOtherMinions))
                    })
                )
            };
        }

        public override Card Copy()
        {
            return new KeeperOfTheGrove();
        }
    }

    public class Starfall : SpellCard
    {
        public Starfall()
        {
            _cardId = CardIds.Starfall;
            _name = "Starfall";
            _hsClass = HSClass.Druid;
            _mana = 5;
            _collectible = true;

            _school = SpellSchool.Arcane;

            _whenPlayedEffect = new ChooseOne(
                new DealDamage(new SelectCharacterFrom(SelectionConstants.AllMinions), 5),
                new DealDamage(SelectionConstants.OtherLivingEnemyMinions, 2)
            );
        }

        public override Card Copy()
        {
            return new Starfall();
        }
    }

    public class Nourish : SpellCard
    {
        public Nourish()
        {
            _cardId = CardIds.Nourish;
            _name = "Nourish";
            _hsClass = HSClass.Druid;
            _mana = 5;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new ChooseOne(
                new GainManaCrystals(SelectionConstants.Player, 2),
                new DrawCards(SelectionConstants.Player, 3)
            );
        }

        public override Card Copy()
        {
            return new Nourish();
        }
    }

    public class ForceOfNature : SpellCard
    {
        public ForceOfNature()
        {
            _cardId = CardIds.ForceOfNature;
            _name = "Force of Nature";
            _hsClass = HSClass.Druid;
            _mana = 5;
            _collectible = true;

            _school = SpellSchool.Nature;

            _whenPlayedEffect = new NEffects(new SummonMinion(new TreantClassic()), 3);
        }

        public override Card Copy()
        {
            return new ForceOfNature();
        }
    }

    public class AncientOfLore : MinionCard
    {
        public AncientOfLore()
        {
            _cardId = CardIds.AncientOfLore;
            _name = "Ancient of Lore";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 7;
            _attack = 7;
            _health = 7;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new ChooseOneTrigger(),
                    new ChooseOne(new List<OneTimeEffect> {
                        new DrawCards(SelectionConstants.Player, 2),
                        new Heal(new SelectCharacterFrom(SelectionConstants.AllOtherCharacters), 7)
                    })
                )
            };
        }

        public override Card Copy()
        {
            return new AncientOfLore();
        }
    }

    public class AncientOfWar : MinionCard
    {
        public AncientOfWar()
        {
            _cardId = CardIds.AncientOfWar;
            _name = "Ancient of War";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 7;
            _attack = 5;
            _health = 5;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new ChooseOneTrigger(),
                    new ChooseOne(new List<OneTimeEffect> {
                        new ChangeAttack(SelectionConstants.OwnSelf, 5),
                        new GiveEMEffect(SelectionConstants.OwnSelf, new List<EMEffect>
                        {
                            new BuffHealth(5), new Taunt()
                        })
                    })
                )
            };
        }

        public override Card Copy()
        {
            return new AncientOfWar();
        }
    }

    public class Cenarius : MinionCard
    {
        public Cenarius()
        {
            _cardId = CardIds.Cenarius;
            _name = "Cenarius";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 8;
            _attack = 5;
            _health = 8;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new ChooseOneTrigger(),
                    new ChooseOne(new List<OneTimeEffect> {
                        new GiveEMEffect(SelectionConstants.AllOtherFriendlyMinions, new Buff(2, 2)),
                        new NEffects(new SummonMinion(new TreantClassicTaunt()), 2)
                    })
                )
            };
        }

        public override Card Copy()
        {
            return new Cenarius();
        }
    }
}
