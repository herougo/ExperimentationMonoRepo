using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralRareTests
    {
        [Fact]
        public Task TestAngryChicken()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
hero_power
select 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YoungPriestess, CardIds.AngryChicken, CardIds.YoungPriestess, CardIds.AngryChicken,
                CardIds.YoungPriestess, CardIds.AngryChicken, CardIds.YoungPriestess
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestBloodsailCorsair()
        {
            string actionText = @"hero_power
attack -1 -1
end_turn
play 0 0
hero_power
play 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodsailCorsair, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestYoungPriestess()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YoungPriestess, CardIds.Wisp, CardIds.YoungPriestess, CardIds.Wisp,
                CardIds.YoungPriestess, CardIds.Wisp, CardIds.YoungPriestess
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestLightwarden()
        {
            string actionText = @"hero_power
play 0 0
play 0 1
end_turn
hero_power
play 0 0
play 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.Lightwarden, CardIds.PriestessOfElune, CardIds.Lightwarden, CardIds.PriestessOfElune,
                CardIds.Lightwarden, CardIds.PriestessOfElune, CardIds.Lightwarden
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warlock);
            return Verify(log);
        }

        [Fact]
        public Task TestMurlocTidecaller()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
play 0 3
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.MurlocTidecaller, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAncientWatcher()
        {
            string actionText = @"play 0 0
end_turn
end_turn
attack 0 -1
play 0 1
select 0 0
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AncientWatcher, CardIds.IronbeakOwl, CardIds.AncientWatcher, CardIds.IronbeakOwl,
                CardIds.AncientWatcher, CardIds.IronbeakOwl, CardIds.AncientWatcher
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestCrazedAlchemist()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
play 1 2
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander, CardIds.CrazedAlchemist,
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }


        [Fact]
        public Task TestKnifeJuggler()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
hero_power
play 0 2
play 0 3
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.KnifeJuggler, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestManaAddict()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
play 3
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ManaAddict, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestManaWraith()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YouthfulBrewmaster, CardIds.ManaWraith, CardIds.YouthfulBrewmaster,
                CardIds.YouthfulBrewmaster, CardIds.Wisp, CardIds.ManaWraith
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warlock);
            return Verify(log);
        }

        [Fact]
        public Task TestMasterSwordsmith()
        {
            string actionText = @"play 0 0
hero_power
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.MasterSwordsmith, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSunfuryProtector()
        {
            string actionText = @"play 0 0
hero_power
play 0 1
end_turn
play 0 0
attack 0 1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SunfuryProtector, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestWildPyromancer()
        {
            string actionText = @"end_turn
play 0 0
hero_power
play 3
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.WildPyromancer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestArcaneGolem()
        {
            string actionText = @"end_turn
end_turn
end_turn
play 4
play 0 0
attack 0 -1
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArcaneGolem, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, false, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestColdlightSeer()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
play 0 3
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.ColdlightSeer, CardIds.ColdlightSeer, CardIds.ColdlightSeer,
                CardIds.ColdlightSeer, CardIds.ColdlightSeer, CardIds.MurlocTidecaller
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestDemolisher()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
play 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Demolisher, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestEmperorCobra()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
play 0 0
end_turn
attack 0 0
attack 1 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.ColdlightSeer, CardIds.ColdlightSeer, CardIds.ColdlightSeer,
                CardIds.EmperorCobra, CardIds.ColdlightSeer, CardIds.EmperorCobra
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestArgentCommander()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
attack 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestGadgetzanAuctioneer()
        {
            string actionText = @"end_turn
play 0 0
play 3
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.GadgetzanAuctioneer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSunwalker()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
attack 0 -1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Sunwalker, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}
