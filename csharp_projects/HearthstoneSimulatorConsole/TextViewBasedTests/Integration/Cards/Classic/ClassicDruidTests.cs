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
