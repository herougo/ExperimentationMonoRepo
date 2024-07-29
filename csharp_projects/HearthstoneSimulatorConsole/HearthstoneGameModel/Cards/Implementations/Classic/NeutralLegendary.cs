using HearthstoneGameModel.CardGeneration;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.HandContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects.WrappedEMEffects;
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
    public class BloodmageThalnos : MinionCard
    {
        public BloodmageThalnos()
        {
            _cardId = CardIds.BloodmageThalnos;
            _name = "Bloodmage Thalnos";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect>
            {
                new SpellDamage(1), new Deathrattle(new DrawCards(SelectionConstants.Player, 1))
            };
        }

        public override Card Copy()
        {
            return new BloodmageThalnos();
        }
    }

    public class LorewalkerCho : MinionCard
    {
        public LorewalkerCho()
        {
            _cardId = CardIds.LorewalkerCho;
            _name = "Lorewalker Cho";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new AfterSpellActivation(new AddEventSlotCopyToHand(PlayerChoice.Opponent), PlayerChoice.Both)
            };
        }

        public override Card Copy()
        {
            return new LorewalkerCho();
        }
    }

    public class MillhouseManastorm : MinionCard
    {
        public MillhouseManastorm()
        {
            _cardId = CardIds.MillhouseManastorm;
            _name = "Millhouse Manastorm";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new GiveEMEffect(
                    SelectionConstants.Opponent,
                    new TimeLimitedEMEffect(
                        new ContinuousSelectionFieldEffect(SelectionConstants.PlayerHandSpells, new ManaSet(0)),
                        EffectTimeLimit.EndOfPlayerTurn,
                        false
                    )
                ))
            };
        }

        public override Card Copy()
        {
            return new MillhouseManastorm();
        }
    }

    public class NatPagle : MinionCard
    {
        public NatPagle()
        {
            _cardId = CardIds.NatPagle;
            _name = "Nat Pagle";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new OnTurnStart(new OneInXChanceEffect(new DrawCards(SelectionConstants.Player, 1), 2))
            };
        }

        public override Card Copy()
        {
            return new NatPagle();
        }
    }

    public class KingMukla : MinionCard
    {
        public KingMukla()
        {
            _cardId = CardIds.KingMukla;
            _name = "King Mukla";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 5;
            _health = 5;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new AddCardToHand(new ConstantCardGenerator(new Banana()), PlayerChoice.Opponent, 2))
            };
        }

        public override Card Copy()
        {
            return new KingMukla();
        }
    }

    public class TinkmasterOverspark : MinionCard
    {
        public TinkmasterOverspark()
        {
            _cardId = CardIds.TinkmasterOverspark;
            _name = "Tinkmaster Overspark";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new TransformInPlayMinion(
                    new RandomCharacterFrom(SelectionConstants.AllOtherMinions),
                    new RandomCardFrom(new List<Card> { new Squirrel(), new Devilsaur() })
                ))
            };
        }

        public override Card Copy()
        {
            return new TinkmasterOverspark();
        }
    }

    public class CaptainGreenskin : MinionCard
    {
        public CaptainGreenskin()
        {
            _cardId = CardIds.CaptainGreenskin;
            _name = "Captain Greenskin";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 5;
            _health = 4;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new GiveEMEffect(SelectionConstants.PlayerWeapon, new BuffWeapon(1, 1)))
            };
        }

        public override Card Copy()
        {
            return new CaptainGreenskin();
        }
    }
}
