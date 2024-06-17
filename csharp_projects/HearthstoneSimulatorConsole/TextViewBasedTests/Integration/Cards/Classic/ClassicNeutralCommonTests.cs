using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralCommonTests
    {
        [Fact]
        public Task TestWisp()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAbusiveSergeant()
        {
            string actionText = @"play 0 0
play 0 0
select 0 0
select 0 1
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AbusiveSergeant, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestArgentSquire()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentSquire, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestLeperGnome()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.LeperGnome, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestShieldbearer()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Shieldbearer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSouthseaDeckhand()
        {
            string actionText = @"play 0 0
attack 0 -1
end_turn
hero_power
play 0 0
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SouthseaDeckhand, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestWorgenInfiltrator()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
attack 0 -1
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.WorgenInfiltrator, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestYoungDragonhawk()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 -1
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.YoungDragonhawk, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAmaniBerserker()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
hero_power
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AmaniBerserker, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Priest);
            return Verify(log);
        }

        [Fact]
        public Task TestBloodsailRaider()
        {
            string actionText = @"hero_power
play 0 0
end_turn
play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodsailRaider, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestDireWolfAlpha()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
play 0 1
end_turn
attack 1 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.DireWolfAlpha, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestFaerieDragon()
        {
            string actionText = @"play 0 0
hero_power
select 0 0
select 0 -1
concede";
            // TODO: test spells too
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.FaerieDragon, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestLootHoarder()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.LootHoarder, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestMadBomber()
        {
            string actionText = @"play 0 0
play 0 0
play 0 0
play 0 0
end_turn
play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.MadBomber, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestYouthfulBrewmaster()
        {
            string actionText = @"play 0 0
hero_power
play 0 2
select 0 2
select 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.YouthfulBrewmaster, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestEarthenRingFarseer()
        {
            string actionText = @"play 0 0
attack 0 -1
end_turn
play 0 0
select 1 -1
play 0 1
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.EarthenRingFarseer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestFlesheatingGhoul()
        {
            string actionText = @"play 0 0
play 0 1
hero_power
end_turn
play 0 0
end_turn
attack 2 0
attack 1 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.FlesheatingGhoul, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FlesheatingGhoul, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestHarvestGolem()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.HarvestGolem, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FaerieDragon, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestIronbeakOwl()
        {
            string actionText = @"hero_power
play 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodsailRaider, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestJunglePanther()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
attack 0 -1
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.JunglePanther, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.JunglePanther, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestRagingWorgen()
        {
            string actionText = @"play 0 0
hero_power
select 0 0
end_turn
end_turn
attack 0 -1
attack 0 -1
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.RagingWorgen, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.RagingWorgen, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestScarletCrusader()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ScarletCrusader, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestTaurenWarrior()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 0
hero_power
select 1 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.TaurenWarrior, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Priest);
            return Verify(log);
        }

        [Fact]
        public Task TestThrallmarFarseer()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 -1
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ThrallmarFarseer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAncientBrewmaster()
        {
            string actionText = @"play 0 0
hero_power
play 0 2
select 0 2
select 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AncientBrewmaster, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestCultMaster()
        {
            string actionText = @"play 0 0
hero_power
play 0 2
end_turn
play 0 0
hero_power
play 0 2
end_turn
attack 1 1
attack 1 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.CultMaster, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestDarkIronDwarf()
        {
            string actionText = @"play 0 0
play 0 0
select 0 0
select 0 1
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.DarkIronDwarf, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestMogushanWarden()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.MogushanWarden, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSilvermoonGuardian()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SilvermoonGuardian, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestFenCreeper()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 -1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FenCreeper, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSilverHandKnight()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SilverHandKnight, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.SilverHandKnight, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSpitefulSmith()
        {
            string actionText = @"play 0 0
hero_power
attack -1 -1
end_turn
hero_power
attack -1 0
end_turn
attack -1 -1
end_turn
end_turn
attack -1 -1
hero_power
attack -1 -1
end_turn
end_turn
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SpitefulSmith, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.SpitefulSmith, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Rogue);
            return Verify(log);
        }
    }
}
