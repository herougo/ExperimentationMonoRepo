using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.GameMechanics
{
    public class PlayCardTests
    {
        [Fact]
        public Task TestCardOutsideRange()
        {
            string actionText = @"play 4 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestNotEnoughMana()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, false, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestDestinationOutsideRange()
        {
            string actionText = @"play 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestNotEnoughSpaceOnTheBattleboard()
        {
            string actionText = @"play 0 0
play 0 0
play 0 0
play 0 0
hero_power
end_turn
end_turn
hero_power
play 0 0
end_turn
end_turn
hero_power
play 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}
