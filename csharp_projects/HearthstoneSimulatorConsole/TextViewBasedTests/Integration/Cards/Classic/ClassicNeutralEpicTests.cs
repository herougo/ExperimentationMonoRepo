using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralEpicTests
    {
        [Fact]
        public Task TestHungryCrab()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
play 0 1
end_turn
play 1 0
select 0 0
select 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.HungryCrab, CardIds.MurlocTidecaller, CardIds.HungryCrab, CardIds.MurlocTidecaller,
                CardIds.HungryCrab, CardIds.MurlocTidecaller, CardIds.HungryCrab, CardIds.MurlocTidecaller
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestDoomsayer()
        {
            string actionText = @"play 0 0
hero_power
end_turn
hero_power
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Doomsayer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}
