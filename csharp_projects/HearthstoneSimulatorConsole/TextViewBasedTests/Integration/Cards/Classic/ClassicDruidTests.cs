using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicDruidTests
    {
        [Fact]
        public Task TestPowerOfTheWild()
        {
            string actionText = @"play 0
choose 1
end_turn
play 0
choose 1
play 0
choose 1
play 0
choose 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.PowerOfTheWild, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestWrath()
        {
            string actionText = @"play 0 0
end_turn
play 0
choose 1
select 0 0
play 0
choose 0
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Gruul, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wrath, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestMarkOfNature()
        {
            string actionText = @"play 0 0
end_turn
play 0
choose 1
select 0 0
play 0
choose 0
select 0 0
hero_power
attack -1 -1
attack -1 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Gruul, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.MarkOfNature, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestSoulOfTheForest()
        {
            string actionText = @"play 0 0
play 0 0
end_turn
play 0 0
play 0 0
play 0
end_turn
attack 0 1
attack 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.SoulOfTheForest, CardIds.SoulOfTheForest, CardIds.AngryChicken, CardIds.AngryChicken
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestDruidOfTheClaw()
        {
            string actionText = @"play 0 0
choose 1
end_turn
play 0 0
play 0 0
play 0 0
end_turn
play 0 1
choose 0
attack 1 -1
attack 1 0
end_turn
attack 0 1
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.DruidOfTheClaw, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.AngryChicken, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestGiftOfTheWild()
        {
            string actionText = @"play 0 0
play 0 0
play 0
end_turn
hero_power
attack -1 -1
attack -1 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.GiftOfTheWild, CardIds.AngryChicken, CardIds.AngryChicken
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestSavagery()
        {
            string actionText = @"play 0 0
play 0 0
hero_power
play 0
select 0 -1
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.Savagery, CardIds.Shieldbearer, CardIds.Shieldbearer
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestBite()
        {
            string actionText = @"play 0
attack -1 -1
end_turn
end_turn
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Bite, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestKeeperOfTheGrove()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
choose 0
select 0 -1
play 0 0
choose 1
select 0 0
hero_power
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Shieldbearer, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.KeeperOfTheGrove, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestStarfall()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0
choose 0
select 0 0
play 0
choose 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.MogushanWarden, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Starfall, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestNourish()
        {
            string actionText = @"play 0
choose 0
play 0
choose 1
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Nourish, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestForceOfNature()
        {
            string actionText = @"play 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ForceOfNature, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestAncientOfLore()
        {
            string actionText = @"play 0 0
choose 0
end_turn
play 0 0
end_turn
hero_power
attack -1 0
play 0 0
choose 1
select 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AncientOfLore, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Deathwing, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestAncientOfWar()
        {
            string actionText = @"play 0 0
choose 1
end_turn
play 0 0
choose 0
hero_power
attack -1 -1
attack -1 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AncientOfWar, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestCenarius()
        {
            string actionText = @"play 0 0
choose 1
end_turn
hero_power
attack -1 -1
attack -1 0
attack -1 1
end_turn
play 0 0
choose 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Cenarius, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }
    }
}
