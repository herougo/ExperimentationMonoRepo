using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.JoinedOneTimeEffects;
using HearthstoneGameModel.Selections.SelectionFilters;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Effects.ContinuousEffects;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class HungryCrab : MinionCard
    {
        public HungryCrab()
        {
            _cardId = CardIds.HungryCrab;
            _name = "Hungry Crab";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new DestroyMinionAndBuff(
                    new SelectCharacterFrom(SelectionConstants.AllOtherMinions & new TagSelectionFilter(MinionTag.Murloc)),
                    SelectionConstants.OwnSelf,
                    2,
                    2
                ))
            };
        }

        public override Card Copy()
        {
            return new HungryCrab();
        }
    }

    public class Doomsayer : MinionCard
    {
        public Doomsayer()
        {
            _cardId = CardIds.Doomsayer;
            _name = "Doomsayer";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 7;

            _inPlayEffects = new List<EMEffect>
            {
                new OnTurnStart(new DestroyMinion(SelectionConstants.AllMinions), PlayerChoice.Player)
            };
        }

        public override Card Copy()
        {
            return new Doomsayer();
        }
    }

    public class BloodKnight : MinionCard
    {
        public BloodKnight()
        {
            _cardId = CardIds.BloodKnight;
            _name = "Blood Knight";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new LoseDivineShieldsAndBuff(SelectionConstants.AllMinions, SelectionConstants.OwnSelf, 3, 3))
            };
        }

        public override Card Copy()
        {
            return new BloodKnight();
        }
    }

    public class MurlocWarleader : MinionCard
    {
        public MurlocWarleader()
        {
            _cardId = CardIds.MurlocWarleader;
            _name = "Murloc Warleader";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;
            _tag = MinionTag.Murloc;

            _inPlayEffects = new List<EMEffect>
            {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.AllOtherFriendlyMinions & new TagSelectionFilter(MinionTag.Murloc),
                    new BuffAttack(2)
                )
            };
        }

        public override Card Copy()
        {
            return new MurlocWarleader();
        }
    }

    public class SouthseaCaptain : MinionCard
    {
        public SouthseaCaptain()
        {
            _cardId = CardIds.SouthseaCaptain;
            _name = "Southsea Captain";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect>
            {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.AllOtherFriendlyMinions & new TagSelectionFilter(MinionTag.Pirate),
                    new Buff(1, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new SouthseaCaptain();
        }
    }

    public class BigGameHunter : MinionCard
    {
        public BigGameHunter()
        {
            _cardId = CardIds.BigGameHunter;
            _name = "Big Game Hunter";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 4;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new DestroyMinion(new SelectCharacterFrom(SelectionConstants.AllOtherMinions & new AttackAtLeastFilter(7))))
            };
        }

        public override Card Copy()
        {
            return new BigGameHunter();
        }
    }

    public class FacelessManipulator : MinionCard
    {
        public FacelessManipulator()
        {
            _cardId = CardIds.FacelessManipulator;
            _name = "Faceless Manipulator";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new BecomeMinionCopy(new SelectCharacterFrom(SelectionConstants.AllOtherMinions)))
            };
        }

        public override Card Copy()
        {
            return new FacelessManipulator();
        }
    }
}
