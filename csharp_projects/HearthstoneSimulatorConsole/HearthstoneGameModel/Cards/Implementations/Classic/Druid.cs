using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Deathrattle(new SummonMinion(new TreantClassic()))
            );
        }

        public override Card Copy()
        {
            return new SoulOfTheForest();
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
}
