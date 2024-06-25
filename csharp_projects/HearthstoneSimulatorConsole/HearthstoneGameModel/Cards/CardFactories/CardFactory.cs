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

                case CardIds.ArgentCommander:
                    return new ArgentCommander();

                case CardIds.DamagedGolem:
                    return new DamagedGolem();
                case CardIds.Squire:
                    return new Squire();

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
