using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicShamanTests
    {
        [Fact]
        public Task TestEarthShock()
        {
            string actionText = @"play 0 0
end_turn
play 0
select 0 -1
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SilvermoonGuardian, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.EarthShock, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Shaman);
            return Verify(log);
        }
    }
}
