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
hero_power
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodmageThalnos, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
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
    }
}