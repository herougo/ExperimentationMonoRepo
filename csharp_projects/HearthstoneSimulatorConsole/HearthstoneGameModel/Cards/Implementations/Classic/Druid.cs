using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
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
