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
    }
}
