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
    }
}
