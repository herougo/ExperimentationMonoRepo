using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Cards.Implementations.Heroes;
using HearthstoneGameModel.Cards.Implementations;

namespace HearthstoneGameModel.Cards.CardFactories
{
    public static class CardFactory
    {
        public static Card CreateCard(string cardId)
        {
            switch (cardId)
            {
                case CardIds.Wisp:
                    return new Wisp();
                case CardIds.AbusiveSergeant:
                    return new AbusiveSergeant();
                case CardIds.ArgentSquire:
                    return new ArgentSquire();
                case CardIds.LeperGnome:
                    return new LeperGnome();
                case CardIds.Shieldbearer:
                    return new Shieldbearer();
                case CardIds.SouthseaDeckhand:
                    return new SouthseaDeckhand();
                case CardIds.WorgenInfiltrator:
                    return new WorgenInfiltrator();
                case CardIds.YoungDragonhawk:
                    return new YoungDragonhawk();
                case CardIds.AmaniBerserker:
                    return new AmaniBerserker();
                case CardIds.BloodsailRaider:
                    return new BloodsailRaider();
                case CardIds.DireWolfAlpha:
                    return new DireWolfAlpha();
                case CardIds.FaerieDragon:
                    return new FaerieDragon();
                case CardIds.LootHoarder:
                    return new LootHoarder();
                case CardIds.MadBomber:
                    return new MadBomber();
                case CardIds.YouthfulBrewmaster:
                    return new YouthfulBrewmaster();
                case CardIds.EarthenRingFarseer:
                    return new EarthenRingFarseer();
                case CardIds.FlesheatingGhoul:
                    return new FlesheatingGhoul();
                case CardIds.HarvestGolem:
                    return new HarvestGolem();
                case CardIds.IronbeakOwl:
                    return new IronbeakOwl();
                case CardIds.JunglePanther:
                    return new JunglePanther();
                case CardIds.RagingWorgen:
                    return new RagingWorgen();
                case CardIds.ScarletCrusader:
                    return new ScarletCrusader();
                case CardIds.TaurenWarrior:
                    return new TaurenWarrior();
                case CardIds.ThrallmarFarseer:
                    return new ThrallmarFarseer();
                case CardIds.AncientBrewmaster:
                    return new AncientBrewmaster();
                case CardIds.CultMaster:
                    return new CultMaster();
                case CardIds.DarkIronDwarf:
                    return new DarkIronDwarf();
                case CardIds.DreadCorsair:
                    return new DreadCorsair();
                case CardIds.MogushanWarden:
                    return new MogushanWarden();
                case CardIds.SilvermoonGuardian:
                    return new SilvermoonGuardian();
                case CardIds.FenCreeper:
                    return new FenCreeper();
                case CardIds.SilverHandKnight:
                    return new SilverHandKnight();
                case CardIds.SpitefulSmith:
                    return new SpitefulSmith();
                case CardIds.StranglethornTiger:
                    return new StranglethornTiger();
                case CardIds.VentureCoMercenary:
                    return new VentureCoMercenary();
                case CardIds.FrostElemental:
                    return new FrostElemental();
                case CardIds.PriestessOfElune:
                    return new PriestessOfElune();
                case CardIds.WindfuryHarpy:
                    return new WindfuryHarpy();

                case CardIds.AngryChicken:
                    return new AngryChicken();
                case CardIds.BloodsailCorsair:
                    return new BloodsailCorsair();
                case CardIds.Lightwarden:
                    return new Lightwarden();
                case CardIds.MurlocTidecaller:
                    return new MurlocTidecaller();
                case CardIds.Secretkeeper:
                    return new Secretkeeper();
                case CardIds.YoungPriestess:
                    return new YoungPriestess();
                case CardIds.AncientWatcher:
                    return new AncientWatcher();
                case CardIds.CrazedAlchemist:
                    return new CrazedAlchemist();
                case CardIds.KnifeJuggler:
                    return new KnifeJuggler();
                case CardIds.ManaAddict:
                    return new ManaAddict();
                case CardIds.ManaWraith:
                    return new ManaWraith();
                case CardIds.MasterSwordsmith:
                    return new MasterSwordsmith();
                case CardIds.PintSizedSummoner:
                    return new PintSizedSummoner();
                case CardIds.SunfuryProtector:
                    return new SunfuryProtector();
                case CardIds.WildPyromancer:
                    return new WildPyromancer();

                case CardIds.ArcaneGolem:
                    return new ArcaneGolem();
                case CardIds.ColdlightSeer:
                    return new ColdlightSeer();
                case CardIds.Demolisher:
                    return new Demolisher();
                case CardIds.EmperorCobra:
                    return new EmperorCobra();
                case CardIds.ImpMaster:
                    return new ImpMaster();
                case CardIds.InjuredBlademaster:
                    return new InjuredBlademaster();
                case CardIds.QuestingAdventurer:
                    return new QuestingAdventurer();
                case CardIds.AncientMage:
                    return new AncientMage();
                case CardIds.DefenderOfArgus:
                    return new DefenderOfArgus();
                case CardIds.TwilightDrake:
                    return new TwilightDrake();

                case CardIds.VioletTeacher:
                    return new VioletTeacher();
                case CardIds.Abomination:
                    return new Abomination();
                case CardIds.StampedingKodo:
                    return new StampedingKodo();
                case CardIds.ArgentCommander:
                    return new ArgentCommander();
                case CardIds.GadgetzanAuctioneer:
                    return new GadgetzanAuctioneer();
                case CardIds.Sunwalker:
                    return new Sunwalker();
                case CardIds.RavenholdtAssassin:
                    return new RavenholdtAssassin();
                case CardIds.ArcaneDevourer:
                    return new ArcaneDevourer();

                case CardIds.HungryCrab:
                    return new HungryCrab();
                case CardIds.Doomsayer:
                    return new Doomsayer();
                case CardIds.BloodKnight:
                    return new BloodKnight();
                case CardIds.MurlocWarleader:
                    return new MurlocWarleader();
                case CardIds.SouthseaCaptain:
                    return new SouthseaCaptain();
                case CardIds.BigGameHunter:
                    return new BigGameHunter();
                case CardIds.FacelessManipulator:
                    return new FacelessManipulator();

                case CardIds.SeaGiant:
                    return new SeaGiant();

                case CardIds.BloodmageThalnos:
                    return new BloodmageThalnos();
                case CardIds.LorewalkerCho:
                    return new LorewalkerCho();
                case CardIds.MillhouseManastorm:
                    return new MillhouseManastorm();
                case CardIds.NatPagle:
                    return new NatPagle();
                case CardIds.KingMukla:
                    return new KingMukla();
                case CardIds.TinkmasterOverspark:
                    return new TinkmasterOverspark();
                case CardIds.CaptainGreenskin:
                    return new CaptainGreenskin();
                case CardIds.HarrisonJones:
                    return new HarrisonJones();
                case CardIds.CairneBloodhoof:
                    return new CairneBloodhoof();
                case CardIds.Hogger:
                    return new Hogger();
                case CardIds.TheBeast:
                    return new TheBeast();
                case CardIds.TheBlackKnight:
                    return new TheBlackKnight();
                case CardIds.Xavius:
                    return new Xavius();
                case CardIds.BaronGeddon:
                    return new BaronGeddon();
                case CardIds.HighInquisitorWhitemane:
                    return new HighInquisitorWhitemane();
                case CardIds.Gruul:
                    return new Gruul();
                case CardIds.Alexstrasza:
                    return new Alexstrasza();
                case CardIds.Malygos:
                    return new Malygos();
                case CardIds.Onyxia:
                    return new Onyxia();
                case CardIds.Ysera:
                    return new Ysera();
                case CardIds.Deathwing:
                    return new Deathwing();

                case CardIds.PowerOfTheWild:
                    return new PowerOfTheWild();
                case CardIds.Wrath:
                    return new Wrath();
                case CardIds.MarkOfNature:
                    return new MarkOfNature();
                case CardIds.SoulOfTheForest:
                    return new SoulOfTheForest();
                case CardIds.DruidOfTheClaw:
                    return new DruidOfTheClaw();
                case CardIds.GiftOfTheWild:
                    return new GiftOfTheWild();
                case CardIds.Savagery:
                    return new Savagery();
                case CardIds.Bite:
                    return new Bite();
                case CardIds.KeeperOfTheGrove:
                    return new KeeperOfTheGrove();
                case CardIds.Starfall:
                    return new Starfall();
                case CardIds.Nourish:
                    return new Nourish();
                case CardIds.ForceOfNature:
                    return new ForceOfNature();
                case CardIds.AncientOfLore:
                    return new AncientOfLore();
                case CardIds.AncientOfWar:
                    return new AncientOfWar();
                case CardIds.Cenarius:
                    return new Cenarius();

                case CardIds.ExplosiveTrap:
                    return new ExplosiveTrap();
                case CardIds.FreezingTrap:
                    return new FreezingTrap();
                case CardIds.Snipe:
                    return new Snipe();
                case CardIds.ScavengingHyena:
                    return new ScavengingHyena();
                case CardIds.DeadlyShot:
                    return new DeadlyShot();
                case CardIds.UnleashTheHounds:
                    return new UnleashTheHounds();
                case CardIds.Flare:
                    return new Flare();

                case CardIds.EaglehornBow:
                    return new EaglehornBow();
                case CardIds.ExplosiveShot:
                    return new ExplosiveShot();
                case CardIds.SavannahHighmane:
                    return new SavannahHighmane();
                case CardIds.BestialWrath:
                    return new BestialWrath();
                case CardIds.SnakeTrap:
                    return new SnakeTrap();
                case CardIds.GladiatorsLongbow:
                    return new GladiatorsLongbow();
                case CardIds.KingKrush:
                    return new KingKrush();

                case CardIds.ManaWyrm:
                    return new ManaWyrm();
                case CardIds.SorcerersApprentice:
                    return new SorcerersApprentice();
                case CardIds.IceBarrier:
                    return new IceBarrier();

                case CardIds.EarthShock:
                    return new EarthShock();

                case CardIds.DamagedGolem:
                    return new DamagedGolem();
                case CardIds.Squire:
                    return new Squire();
                case CardIds.Imp:
                    return new Imp();
                case CardIds.VioletApprentice:
                    return new VioletApprentice();
                case CardIds.Banana:
                    return new Banana();
                case CardIds.Squirrel:
                    return new Squirrel();
                case CardIds.Devilsaur:
                    return new Devilsaur();
                case CardIds.BaineBloodhoof:
                    return new BaineBloodhoof();
                case CardIds.Gnoll:
                    return new Gnoll();
                case CardIds.PipQuickwit:
                    return new PipQuickwit();
                case CardIds.XavianSatyr:
                    return new XavianSatyr();
                case CardIds.Whelp:
                    return new Whelp();
                case CardIds.Dream:
                    return new Dream();
                case CardIds.Nightmare:
                    return new Nightmare();
                case CardIds.LaughingSister:
                    return new LaughingSister();
                case CardIds.YseraAwakens:
                    return new YseraAwakens();
                case CardIds.EmeraldDrake:
                    return new EmeraldDrake();

                case CardIds.Panther:
                    return new Panther();
                case CardIds.TreantClassic:
                    return new TreantClassic();
                case CardIds.DruidOfTheClawBearForm:
                    return new DruidOfTheClawBearForm();
                case CardIds.DruidOfTheClawCatForm:
                    return new DruidOfTheClawCatForm();
                case CardIds.TreantClassicTaunt:
                    return new TreantClassicTaunt();

                case CardIds.Hound:
                    return new Hound();
                case CardIds.Hyena:
                    return new Hyena();
                case CardIds.Snake:
                    return new Snake();

                case CardIds.Priest:
                    return new Priest();
                case CardIds.Rogue:
                    return new Rogue();
                case CardIds.Druid:
                    return new Druid();
                case CardIds.Shaman:
                    return new Shaman();
                case CardIds.Warlock:
                    return new Warlock();
                case CardIds.Paladin:
                    return new Paladin();
                case CardIds.Warrior:
                    return new Warrior();
                case CardIds.Hunter:
                    return new Hunter();
                case CardIds.Mage:
                    return new Mage();
                case CardIds.DemonHunter:
                    return new DemonHunter();

                case CardIds.RogueDagger12:
                    return new RogueDagger12();
                case CardIds.SilverHandRecruit:
                    return new SilverHandRecruit();
                case CardIds.SearingTotem:
                    return new SearingTotem();
                case CardIds.StoneclawTotem:
                    return new StoneclawTotem();
                case CardIds.StrengthTotem:
                    return new StrengthTotem();
                case CardIds.HealingTotem:
                    return new HealingTotem();

                case CardIds.Coin:
                    return new Coin();
                default:
                    throw new ArgumentException($"Unsupported cardId: {cardId}");
            }
        }
    }
}
