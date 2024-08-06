using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralLegendaryTests
    {
        [Fact]
        public Task TestBloodmageThalnos()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
play 0
select 1 0
attack 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock,
                CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock, CardIds.BloodmageThalnos
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.SilvermoonGuardian, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestLorewalkerCho()
        {
            string actionText = @"play 0 0
end_turn
play 4
play 0 0
end_turn
play 3
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.LorewalkerCho, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestMillhouseManastorm()
        {
            string actionText = @"play 0 0
end_turn
play 1
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.Bite, CardIds.Bite, CardIds.Bite, CardIds.Bite,
                CardIds.Bite, CardIds.Bite, CardIds.Bite, CardIds.MillhouseManastorm
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestNatPagle()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
play 0 1
end_turn
end_turn
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.NatPagle, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestKingMukla()
        {
            string actionText = @"play 0 0
end_turn
play 5
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.KingMukla, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestTinkmasterOverspark()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
play 0 1
play 0 2
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.DireWolfAlpha, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.TinkmasterOverspark, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestCaptainGreenskin()
        {
            string actionText = @"hero_power
play 0 0
attack -1 -1
end_turn
hero_power
attack -1 -1
play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.CaptainGreenskin, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestHarrisonJones()
        {
            string actionText = @"play 0 0
hero_power
end_turn
play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.HarrisonJones, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestCairneBloodhoof()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.CairneBloodhoof, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.HarrisonJones, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestHogger()
        {
            string actionText = @"play 0 0
end_turn
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Hogger, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestTheBeast()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.TheBeast, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.BigGameHunter, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestTheBlackKnight()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
select 0 0
select 0 -1
select 0 2
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.Hogger, CardIds.TheBlackKnight, CardIds.Hogger, CardIds.TheBlackKnight,
                CardIds.Hogger, CardIds.TheBlackKnight, CardIds.Hogger, CardIds.TheBlackKnight
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestXavius()
        {
            string actionText = @"play 0 0
hero_power
play 0 2
end_turn
play 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.Xavius
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestBaronGeddon()
        {
            string actionText = @"hero_power
end_turn
play 0 0
play 0 1
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.SunfuryProtector, CardIds.SunfuryProtector, CardIds.SunfuryProtector, CardIds.SunfuryProtector,
                CardIds.SunfuryProtector, CardIds.SunfuryProtector, CardIds.SunfuryProtector, CardIds.BaronGeddon
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestHighInquisitorWhitemane()
        {
            string actionText = @"hero_power
end_turn
play 1 0
end_turn
attack 0 0
play 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.HighInquisitorWhitemane
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestGruul()
        {
            string actionText = @"play 0 0
end_turn
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Gruul, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAlexstrasza()
        {
            string actionText = @"play 0 0
select 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Alexstrasza, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestMalygos()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
play 0
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock,
                CardIds.EarthShock, CardIds.EarthShock, CardIds.EarthShock, CardIds.Malygos
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestOnyxia()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Onyxia, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestYsera()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
play 0
play 0 1
play 0
select 1 1
select 1 0
play 0
select 0 0
end_turn
play 0 1
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Ysera, 30).ToList();
            List<string> cardIdList1 = new List<string>
            {
                CardIds.Dream, CardIds.Dream, CardIds.Dream, CardIds.Dream,
                CardIds.Nightmare, CardIds.LaughingSister, CardIds.YseraAwakens, CardIds.EmeraldDrake
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}