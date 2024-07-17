using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class VariousEdgeCaseTests
    {
        [Fact]
        public Task TestHeroPowerPingArgentSquire()
        {
            string actionText = @"play 0 0
hero_power
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentSquire, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }
    }
}
