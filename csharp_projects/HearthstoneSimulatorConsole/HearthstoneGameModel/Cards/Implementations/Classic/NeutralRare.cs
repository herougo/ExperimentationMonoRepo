using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.WrappedEMEffects;
using HearthstoneGameModel.Conditions;
using HearthstoneGameModel.Effects.TriggerEffects;
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Game.Action;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Selections.SlotSelections;
using HearthstoneGameModel.Effects.WrappedOneTimeEffects;
using HearthstoneGameModel.Effects.HandContinuousEffects;

namespace HearthstoneGameModel.Cards.Implementations.Classic
{
    public class AngryChicken : MinionCard
    {
        public AngryChicken()
        {
            _cardId = CardIds.AngryChicken;
            _name = "Angry Chicken";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 1;
            _tag = MinionTag.Beast;

            _inPlayEffects = new List<EMEffect> {
                new ConditionalEffect(
                    new WhileSelfDamaged(),
                    new BuffAttack(5)
                )
            };
        }

        public override Card Copy()
        {
            return new AngryChicken();
        }
    }

    public class BloodsailCorsair : MinionCard
    {
        public BloodsailCorsair()
        {
            _cardId = CardIds.BloodsailCorsair;
            _name = "Bloodsail Corsair";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;
            _tag = MinionTag.Pirate;

            _inPlayEffects = new List<EMEffect> {
                new Battlecry(new ReduceWeaponDurability(1, true))
            };
        }

        public override Card Copy()
        {
            return new BloodsailCorsair();
        }
    }

    public class Lightwarden : MinionCard
    {
        public Lightwarden()
        {
            _cardId = CardIds.Lightwarden;
            _name = "Lightwarden";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new WhenACharacterIsHealed(new ChangeAttack(SelectionConstants.OwnSelf, 2))
            };
        }

        public override Card Copy()
        {
            return new Lightwarden();
        }
    }

    public class MurlocTidecaller : MinionCard
    {
        public MurlocTidecaller()
        {
            _cardId = CardIds.MurlocTidecaller;
            _name = "Murloc Tidecaller";
            _hsClass = HeroClass.Neutral;
            _collectible = true;
            
            _mana = 1;
            _attack = 1;
            _health = 2;
            _tag = MinionTag.Murloc;

            _inPlayEffects = new List<EMEffect>
            {
                new WhenYouSummonOtherMinion(new ChangeAttack(SelectionConstants.OwnSelf, 1), MinionTag.Murloc)
            };
        }

        public override Card Copy()
        {
            return new MurlocTidecaller();
        }
    }

    public class Secretkeeper : MinionCard
    {
        public Secretkeeper()
        {
            _cardId = CardIds.Secretkeeper;
            _name = "Secretkeeper";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 1;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                // TODO
            };
        }

        public override Card Copy()
        {
            return new MurlocTidecaller();
        }
    }

    public class YoungPriestess : MinionCard
    {
        public YoungPriestess()
        {
            _cardId = CardIds.YoungPriestess;
            _name = "Young Priestess";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 1;
            _attack = 2;
            _health = 1;

            _inPlayEffects = new List<EMEffect>
            {
                new OnTurnEnd(new ChangeHealth(SelectionConstants.RandomOtherFriendlyMinion, 1))
            };
        }

        public override Card Copy()
        {
            return new MurlocTidecaller();
        }
    }

    public class AncientWatcher : MinionCard
    {
        public AncientWatcher()
        {
            _cardId = CardIds.AncientWatcher;
            _name = "Ancient Watcher";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 4;
            _health = 5;

            _inPlayEffects = new List<EMEffect>
            {
                new CantAttack()
            };
        }

        public override Card Copy()
        {
            return new MurlocTidecaller();
        }
    }

    public class KnifeJuggler : MinionCard
    {
        public KnifeJuggler()
        {
            _cardId = CardIds.KnifeJuggler;
            _name = "Knife Juggler";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 3;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new WhenYouSummonOtherMinion(new DealDamage(SelectionConstants.RandomOtherLivingEnemy, 1), MinionTag.Any)
            };
        }

        public override Card Copy()
        {
            return new KnifeJuggler();
        }
    }

    public class ManaAddict : MinionCard
    {
        public ManaAddict()
        {
            _cardId = CardIds.ManaAddict;
            _name = "Mana Addict";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 1;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new AfterSpellActivation(
                    new TimeLimitedOneTimeEffect(
                        new ChangeAttack(SelectionConstants.OwnSelf, 2),
                        EffectTimeLimit.EndOfTurn
                    ),
                    PlayerChoice.Player
                )
            };
        }

        public override Card Copy()
        {
            return new ManaAddict();
        }
    }

    public class ManaWraith : MinionCard
    {
        public ManaWraith()
        {
            _cardId = CardIds.ManaWraith;
            _name = "Mana Wraith";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new ContinuousSelectionFieldEffect(
                    SelectionConstants.AllHandMinions,
                    new ManaChange(1, 1)
                )
            };
        }

        public override Card Copy()
        {
            return new ManaWraith();
        }
    }

    public class MasterSwordsmith : MinionCard
    {
        public MasterSwordsmith()
        {
            _cardId = CardIds.MasterSwordsmith;
            _name = "Master Swordsmith";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 1;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new OnTurnEnd(new ChangeAttack(SelectionConstants.RandomOtherFriendlyMinion, 1))
            };
        }

        public override Card Copy()
        {
            return new MasterSwordsmith();
        }
    }

    public class SunfuryProtector : MinionCard
    {
        public SunfuryProtector()
        {
            _cardId = CardIds.SunfuryProtector;
            _name = "Sunfury Protector";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 2;
            _health = 3;

            _inPlayEffects = new List<EMEffect>
            {
                new Battlecry(new GiveContinuousEffect(SelectionConstants.AdjacentMinions, new Taunt()))
            };
        }

        public override Card Copy()
        {
            return new SunfuryProtector();
        }
    }

    public class WildPyromancer : MinionCard
    {
        public WildPyromancer()
        {
            _cardId = CardIds.WildPyromancer;
            _name = "Wild Pyromancer";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 2;
            _attack = 3;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new AfterSpellActivation(new DealDamage(SelectionConstants.AllMinions, 1), PlayerChoice.Player)
            };
        }

        public override Card Copy()
        {
            return new WildPyromancer();
        }
    }


    public class ArgentCommander : MinionCard
    {
        public ArgentCommander()
        {
            _cardId = CardIds.ArgentCommander;
            _name = "Argent Commander";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 4;
            _health = 2;

            _inPlayEffects = new List<EMEffect>
            {
                new DivineShield(), new Charge()
            };
        }

        public override Card Copy()
        {
            return new ArgentCommander();
        }
    }


    public class GadgetzanAuctioneer : MinionCard
    {
        public GadgetzanAuctioneer()
        {
            _cardId = CardIds.GadgetzanAuctioneer;
            _name = "Gadgetzan Auctioneer";
            _hsClass = HeroClass.Neutral;
            _collectible = true;

            _mana = 6;
            _attack = 4;
            _health = 4;

            _inPlayEffects = new List<EMEffect>
            {
                new AfterSpellActivation(new DrawCards(SelectionConstants.Player, 1), PlayerChoice.Player)
            };
        }

        public override Card Copy()
        {
            return new GadgetzanAuctioneer();
        }
    }
}
