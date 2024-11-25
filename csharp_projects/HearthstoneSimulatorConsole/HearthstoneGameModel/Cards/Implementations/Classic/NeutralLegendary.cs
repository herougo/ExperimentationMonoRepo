﻿using HearthstoneGameModel.CardGeneration;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.HandContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SelectionFilters;
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect>
            {
                new SpellDamage(1),
                new TriggerEffect(
                    new Deathrattle(),
                    new DrawCards(SelectionConstants.Player, 1)
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new AfterSpellActivation(PlayerChoice.Both),
                    new AddEventSlotCopyToHand(PlayerChoice.Opponent)
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new GiveEMEffect(
                        SelectionConstants.Opponent,
                        new TimeLimitedEMEffect(
                            new ContinuousSelectionFieldEffect(SelectionConstants.PlayerHandSpells, new ManaSet(0)),
                            EffectTimeLimit.EndOfPlayerTurn,
                            false
                        )
                    )
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 0;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new OnTurnStart(),
                    new OneInXChanceEffect(new DrawCards(SelectionConstants.Player, 1), 2)
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 5;
            _health = 5;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new AddCardToHand(new ConstantCardGenerator(new Banana()), PlayerChoice.Opponent, 2)
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new TransformInPlayMinion(
                        new RandomCharacterFrom(SelectionConstants.AllOtherMinions),
                        new RandomCardFrom(new List<Card> { new Squirrel(), new Devilsaur() })
                    )
                )
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 5;
            _health = 4;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new GiveEMEffect(SelectionConstants.PlayerWeapon, new BuffWeapon(1, 1))
                )
            };
        }

        public override Card Copy()
        {
            return new CaptainGreenskin();
        }
    }

    public class HarrisonJones : MinionCard
    {
        public HarrisonJones()
        {
            _cardId = CardIds.HarrisonJones;
            _name = "Harrison Jones";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 5;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new DestroyWeaponAndDrawDurability(PlayerChoice.Opponent, PlayerChoice.Player)
                )
            };
        }

        public override Card Copy()
        {
            return new HarrisonJones();
        }
    }

    public class CairneBloodhoof : MinionCard
    {
        public CairneBloodhoof()
        {
            _cardId = CardIds.CairneBloodhoof;
            _name = "Cairne Bloodhoof";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 5;
            _health = 5;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Deathrattle(),
                    new SummonMinion(new BaineBloodhoof())
                )
            };
        }

        public override Card Copy()
        {
            return new CairneBloodhoof();
        }
    }

    public class Hogger : MinionCard
    {
        public Hogger()
        {
            _cardId = CardIds.Hogger;
            _name = "Hogger";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new OnTurnEnd(),
                    new SummonMinion(new Gnoll())
                )
            };
        }

        public override Card Copy()
        {
            return new Hogger();
        }
    }

    public class TheBeast : MinionCard
    {
        public TheBeast()
        {
            _cardId = CardIds.TheBeast;
            _name = "The Beast";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 9;
            _health = 7;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Deathrattle(),
                    new SummonMinion(new PipQuickwit(), PlayerChoice.Opponent)
                )
            };
        }

        public override Card Copy()
        {
            return new TheBeast();
        }
    }

    public class TheBlackKnight : MinionCard
    {
        public TheBlackKnight()
        {
            _cardId = CardIds.TheBlackKnight;
            _name = "The Black Knight";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 4;
            _health = 4;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new DestroyMinion(
                        new SelectCharacterFrom(
                            SelectionConstants.OtherLivingEnemyMinions & new TauntFilter()
                        )
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new TheBeast();
        }
    }

    public class Xavius : MinionCard
    {
        public Xavius()
        {
            _cardId = CardIds.Xavius;
            _name = "Xavius";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 7;
            _health = 5;
            _tag = MinionTag.Demon;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new WhenOtherCardPlayed(PlayerChoice.Player),
                    new SummonMinion(new XavianSatyr())
                )
            };
        }

        public override Card Copy()
        {
            return new Xavius();
        }
    }

    public class BaronGeddon : MinionCard
    {
        public BaronGeddon()
        {
            _cardId = CardIds.BaronGeddon;
            _name = "Baron Geddon";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 7;
            _attack = 7;
            _health = 7;
            _tag = MinionTag.Elemental;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new OnTurnEnd(),
                    new DealDamage(SelectionConstants.AllOtherCharacters, 2)
                )
            };
        }

        public override Card Copy()
        {
            return new BaronGeddon();
        }
    }

    public class HighInquisitorWhitemane : MinionCard
    {
        public HighInquisitorWhitemane()
        {
            _cardId = CardIds.HighInquisitorWhitemane;
            _name = "High Inquisitor Whitemane";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 5;
            _health = 7;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new SummonFriendlyMinionsThatDiedThisTurn()
                )
            };
        }

        public override Card Copy()
        {
            return new HighInquisitorWhitemane();
        }
    }

    public class Gruul : MinionCard
    {
        public Gruul()
        {
            _cardId = CardIds.Gruul;
            _name = "Gruul";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 8;
            _attack = 7;
            _health = 7;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new OnTurnEnd(PlayerChoice.Both),
                    new ChangeStats(SelectionConstants.OwnSelf, 1, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new Gruul();
        }
    }

    public class Alexstrasza : MinionCard
    {
        public Alexstrasza()
        {
            _cardId = CardIds.Alexstrasza;
            _name = "Alexstrasza";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 9;
            _attack = 8;
            _health = 8;

            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new SetRemainingHealth(new SelectCharacterFrom(SelectionConstants.BothPlayers), 15)
                )
            };
        }

        public override Card Copy()
        {
            return new Alexstrasza();
        }
    }

    public class Malygos : MinionCard
    {
        public Malygos()
        {
            _cardId = CardIds.Malygos;
            _name = "Malygos";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 9;
            _attack = 4;
            _health = 12;

            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect>
            {
                new SpellDamage(5)
            };
        }

        public override Card Copy()
        {
            return new Malygos();
        }
    }

    public class Onyxia : MinionCard
    {
        public Onyxia()
        {
            _cardId = CardIds.Onyxia;
            _name = "Onyxia";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 9;
            _attack = 8;
            _health = 8;

            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new SummonMinionUntilFull(new Whelp())
                )
            };
        }

        public override Card Copy()
        {
            return new Onyxia();
        }
    }

    public class Ysera : MinionCard
    {
        public Ysera()
        {
            _cardId = CardIds.Ysera;
            _name = "Ysera";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 9;
            _attack = 4;
            _health = 12;

            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new OnTurnEnd(PlayerChoice.Player),
                    new AddCardToHand(
                        new RandomCardFrom(new List<Card> {
                            new Dream(), new Nightmare(), new LaughingSister(),
                            new YseraAwakens(), new EmeraldDrake()
                        })
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new Ysera();
        }
    }

    public class Deathwing : MinionCard
    {
        public Deathwing()
        {
            _cardId = CardIds.Deathwing;
            _name = "Deathwing";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 10;
            _attack = 12;
            _health = 12;

            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect>
            {
                new TriggerEffect(
                    new Battlecry(),
                    new OneTimeEffectSequence(
                        new List<OneTimeEffect>{
                            new DestroyMinion(SelectionConstants.AllOtherMinions),
                            new DiscardCards(SelectionConstants.PlayerHand)
                        }
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new Deathwing();
        }
    }
}
