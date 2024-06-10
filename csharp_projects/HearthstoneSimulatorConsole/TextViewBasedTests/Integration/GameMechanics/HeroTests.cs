using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.GameMechanics
{
    public class HeroTests
    {
        /*
         * Priest
         * Rogue
         * Druid
         * Shaman
         * Warlock
         * Paladin
         * Warrior
         * Hunter
         * Mage
         * Demon Hunter
         */
        [Fact]
        public Task TestPriest()
        {
            string actionText = @"play 0 0
attack 0 -1
end_turn
hero_power
select 1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Priest);
            return Verify(log);
        }

        [Fact]
        public Task TestRogue()
        {
            string actionText = @"hero_power
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestDruid()
        {
            string actionText = @"hero_power
attack -1 -1
end_turn
end_turn
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Druid);
            return Verify(log);
        }

        [Fact]
        public Task TestShaman()
        {
            string actionText = @"hero_power
end_turn
end_turn
hero_power
end_turn
end_turn
hero_power
end_turn
end_turn
hero_power
end_turn
end_turn
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Shaman);
            return Verify(log);
        }

        [Fact]
        public Task TestWarlock()
        {
            string actionText = @"hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warlock);
            return Verify(log);
        }

        [Fact]
        public Task TestPaladin()
        {
            string actionText = @"hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestWarrior()
        {
            string actionText = @"hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warrior);
            return Verify(log);
        }

        [Fact]
        public Task TestHunter()
        {
            string actionText = @"hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestMage()
        {
            string actionText = @"hero_power
select 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestDemonHunter()
        {
            string actionText = @"hero_power
attack -1 -1
end_turn
end_turn
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.DemonHunter);
            return Verify(log);
        }
    }
}
