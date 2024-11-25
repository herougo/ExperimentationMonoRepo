﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Conditions;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects.HandContinuousEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.ValueMonitors;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class Wisp : MinionCard
    {
        public Wisp()
        {
            _cardId = CardIds.Wisp;
            _name = "Wisp";
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new TimeLimitedOneTimeEffect(
                        new ChangeAttack(new SelectCharacterFrom(SelectionConstants.AllOtherFriendlyMinions), 2),
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 2;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Deathrattle(),
                    new DealDamage(SelectionConstants.Opponent, 2)
                )
            };
        }

        public override Card Copy()
        {
            return new LeperGnome();
        }
    }

    public class Shieldbearer : MinionCard
    {
        public Shieldbearer()
        {
            _cardId = CardIds.Shieldbearer;
            _name = "Shieldbearer";
            _hsClass = HSClass.Neutral;
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
            return new Shieldbearer();
        }
    }

    public class SouthseaDeckhand : MinionCard
    {
        public SouthseaDeckhand()
        {
            _cardId = CardIds.SouthseaDeckhand;
            _name = "Southsea Deckhand";
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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
            _hsClass = HSClass.Neutral;
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

    public class BloodsailRaider : MinionCard
    {
        public BloodsailRaider()
        {
            _cardId = CardIds.BloodsailRaider;
            _name = "Bloodsail Raider";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 3;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new ChangeAttack(
                        SelectionConstants.OwnSelf,
                        new OwnWeaponAttackIntValue()
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new BloodsailRaider();
        }
    }

    public class DireWolfAlpha : MinionCard
    {
        public DireWolfAlpha()
        {
            _cardId = CardIds.DireWolfAlpha;
            _name = "Dire Wolf Alpha";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 2;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.AdjacentMinions,
                    new BuffAttack(1)
                )
            };
        }

        public override Card Copy()
        {
            return new DireWolfAlpha();
        }
    }

    public class FaerieDragon : MinionCard
    {
        public FaerieDragon()
        {
            _cardId = CardIds.FaerieDragon;
            _name = "Faerie Dragon";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 3;
            _health = 2;
            _tag = MinionTag.Dragon;

            _inPlayEffects = new List<EMEffect> {
                new Elusive()
            };
        }

        public override Card Copy()
        {
            return new FaerieDragon();
        }
    }

    public class LootHoarder : MinionCard
    {
        public LootHoarder()
        {
            _cardId = CardIds.LootHoarder;
            _name = "Loot Hoarder";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Deathrattle(),
                    new DrawCards(SelectionConstants.Player, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new LootHoarder();
        }
    }

    public class MadBomber : MinionCard
    {
        public MadBomber()
        {
            _cardId = CardIds.MadBomber;
            _name = "Mad Bomber";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 3;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new NEffects(
                        new DealDamage(
                            new RandomCharacterFrom(SelectionConstants.OtherLivingCharacters), 1), 
                            3
                        )
                    )
            };
        }

        public override Card Copy()
        {
            return new MadBomber();
        }
    }

    public class YouthfulBrewmaster : MinionCard
    {
        public YouthfulBrewmaster()
        {
            _cardId = CardIds.YouthfulBrewmaster;
            _name = "Youthful Brewmaster";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 3;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new ReturnMinionToHand(new SelectCharacterFrom(SelectionConstants.AllOtherFriendlyMinions))
                )
            };
        }

        public override Card Copy()
        {
            return new YouthfulBrewmaster();
        }
    }

    public class EarthenRingFarseer : MinionCard
    {
        public EarthenRingFarseer()
        {
            _cardId = CardIds.EarthenRingFarseer;
            _name = "Earthen Ring Farseer";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new Heal(new SelectCharacterFrom(SelectionConstants.AllOtherCharacters), 3)
                )
            };
        }

        public override Card Copy()
        {
            return new EarthenRingFarseer();
        }
    }

    public class FlesheatingGhoul : MinionCard
    {
        public FlesheatingGhoul()
        {
            _cardId = CardIds.FlesheatingGhoul;
            _name = "Flesheating Ghoul";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new WhenOtherMinionDies(PlayerChoice.Both),
                    new ChangeAttack(SelectionConstants.OwnSelf, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new FlesheatingGhoul();
        }
    }

    public class HarvestGolem : MinionCard
    {
        public HarvestGolem()
        {
            _cardId = CardIds.HarvestGolem;
            _name = "Harvest Golem";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 2;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Deathrattle(),
                    new SummonMinion(new DamagedGolem())
                )
            };
        }

        public override Card Copy()
        {
            return new HarvestGolem();
        }
    }

    public class IronbeakOwl : MinionCard
    {
        public IronbeakOwl()
        {
            _cardId = CardIds.IronbeakOwl;
            _name = "Ironbeak Owl";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 2;
            _health = 1;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new Silence(new SelectCharacterFrom(SelectionConstants.AllOtherMinions))
                )
            };
        }

        public override Card Copy()
        {
            return new IronbeakOwl();
        }
    }

    public class JunglePanther : MinionCard
    {
        public JunglePanther()
        {
            _cardId = CardIds.JunglePanther;
            _name = "Jungle Panther";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 4;
            _health = 2;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new Stealth()
            };
        }

        public override Card Copy()
        {
            return new JunglePanther();
        }
    }

    public class RagingWorgen : MinionCard
    {
        public RagingWorgen()
        {
            _cardId = CardIds.RagingWorgen;
            _name = "Raging Worgen";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new GroupContinuousEffect(
                        new List<ContinuousEffect>
                        {
                            new BuffAttack(1), new Windfury()
                        }
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new RagingWorgen();
        }
    }

    public class ScarletCrusader : MinionCard
    {
        public ScarletCrusader()
        {
            _cardId = CardIds.ScarletCrusader;
            _name = "Scarlet Crusader";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 3;
            _health = 1;

            _inPlayEffects = new List<EMEffect> {
                new DivineShield()
            };
        }

        public override Card Copy()
        {
            return new ScarletCrusader();
        }
    }

    public class TaurenWarrior : MinionCard
    {
        public TaurenWarrior()
        {
            _cardId = CardIds.TaurenWarrior;
            _name = "Tauren Warrior";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 2;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new Taunt(),
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new BuffAttack(3)
                )
            };
        }

        public override Card Copy()
        {
            return new TaurenWarrior();
        }
    }

    public class ThrallmarFarseer : MinionCard
    {
        public ThrallmarFarseer()
        {
            _cardId = CardIds.ThrallmarFarseer;
            _name = "Thrallmar Farseer";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 3;
            _attack = 2;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new Windfury()
            };
        }

        public override Card Copy()
        {
            return new ThrallmarFarseer();
        }
    }

    public class AncientBrewmaster : MinionCard
    {
        public AncientBrewmaster()
        {
            _cardId = CardIds.AncientBrewmaster;
            _name = "Ancient Brewmaster";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 5;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new ReturnMinionToHand(
                        new SelectCharacterFrom(SelectionConstants.AllOtherFriendlyMinions)
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new AncientBrewmaster();
        }
    }

    public class CultMaster : MinionCard
    {
        public CultMaster()
        {
            _cardId = CardIds.CultMaster;
            _name = "Cult Master";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 4;
            _health = 2;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new WhenOtherMinionDies(PlayerChoice.Player),
                    new DrawCards(SelectionConstants.Player, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new CultMaster();
        }
    }

    public class DarkIronDwarf : MinionCard
    {
        public DarkIronDwarf()
        {
            _cardId = CardIds.DarkIronDwarf;
            _name = "Dark Iron Dwarf";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new TimeLimitedOneTimeEffect(
                        new ChangeAttack(new SelectCharacterFrom(SelectionConstants.AllOtherMinions), 2),
                        EffectTimeLimit.EndOfTurn
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new DarkIronDwarf();
        }
    }

    public class DreadCorsair : MinionCard
    {
        public DreadCorsair()
        {
            _cardId = CardIds.DreadCorsair;
            _name = "Dread Corsair";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new Taunt()
            };
            _inHandEffects = new List<EMEffect> {
                new ContinuousMonitorEffect(
                    new ManaChange(new OwnWeaponAttackIntValue(), -1),
                    new OwnWeaponAttackIntValueMonitor()
                )
            };
        }

        public override Card Copy()
        {
            return new DreadCorsair();
        }
    }

    public class MogushanWarden : MinionCard
    {
        public MogushanWarden()
        {
            _cardId = CardIds.MogushanWarden;
            _name = "Mogushan Warden";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 1;
            _health = 7;

            _inPlayEffects = new List<EMEffect> {
                new Taunt()
            };
        }

        public override Card Copy()
        {
            return new MogushanWarden();
        }
    }

    public class SilvermoonGuardian : MinionCard
    {
        public SilvermoonGuardian()
        {
            _cardId = CardIds.SilvermoonGuardian;
            _name = "Silvermoon Guardian";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 4;
            _attack = 3;
            _health = 3;

            _inPlayEffects = new List<EMEffect> {
                new DivineShield()
            };
        }

        public override Card Copy()
        {
            return new SilvermoonGuardian();
        }
    }

    public class FenCreeper : MinionCard
    {
        public FenCreeper()
        {
            _cardId = CardIds.FenCreeper;
            _name = "Fen Creeper";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 3;
            _health = 6;

            _inPlayEffects = new List<EMEffect> {
                new Taunt()
            };
        }

        public override Card Copy()
        {
            return new FenCreeper();
        }
    }

    public class SilverHandKnight : MinionCard
    {
        public SilverHandKnight()
        {
            _cardId = CardIds.SilverHandKnight;
            _name = "Silver Hand Knight";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new SummonMinion(new Squire())
                )
            };
        }

        public override Card Copy()
        {
            return new SilverHandKnight();
        }
    }

    public class SpitefulSmith : MinionCard
    {
        public SpitefulSmith()
        {
            _cardId = CardIds.SpitefulSmith;
            _name = "Spiteful Smith";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 4;
            _health = 6;
            _tag = MinionTag.Undead;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new ContinuousSelectionFieldEffect(
                        SelectionConstants.PlayerWeapon,
                        new BuffAttack(2)
                    )
                )
            };
        }

        public override Card Copy()
        {
            return new SpitefulSmith();
        }
    }

    public class StranglethornTiger : MinionCard
    {
        public StranglethornTiger()
        {
            _cardId = CardIds.StranglethornTiger;
            _name = "Stranglethorn Tiger";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 5;
            _health = 5;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new Stealth()
            };
        }

        public override Card Copy()
        {
            return new StranglethornTiger();
        }
    }

    public class VentureCoMercenary : MinionCard
    {
        public VentureCoMercenary()
        {
            _cardId = CardIds.VentureCoMercenary;
            _name = "Venture Co. Mercenary";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 5;
            _attack = 7;
            _health = 6;

            _inPlayEffects = new List<EMEffect> {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.PlayerHandMinions,
                    new ManaChange(3, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new VentureCoMercenary();
        }
    }

    public class FrostElemental : MinionCard
    {
        public FrostElemental()
        {
            _cardId = CardIds.FrostElemental;
            _name = "Frost Elemental";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 5;
            _health = 5;
            _tag = MinionTag.Elemental;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new Freeze(new SelectCharacterFrom(SelectionConstants.AllOtherCharacters))
                )
            };
        }

        public override Card Copy()
        {
            return new FrostElemental();
        }
    }

    public class PriestessOfElune : MinionCard
    {
        public PriestessOfElune()
        {
            _cardId = CardIds.PriestessOfElune;
            _name = "Priestess Of Elune";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 5;
            _health = 4;

            _inPlayEffects = new List<EMEffect> {
                new TriggerEffect(
                    new Battlecry(),
                    new Heal(SelectionConstants.Player, 4)
                )
            };
        }

        public override Card Copy()
        {
            return new PriestessOfElune();
        }
    }
    public class WindfuryHarpy : MinionCard
    {
        public WindfuryHarpy()
        {
            _cardId = CardIds.WindfuryHarpy;
            _name = "Windfury Harpy";
            _hsClass = HSClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 4;
            _health = 5;

            _inPlayEffects = new List<EMEffect> {
                new Windfury()
            };
        }

        public override Card Copy()
        {
            return new WindfuryHarpy();
        }
    }
}

