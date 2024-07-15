using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class PoisonousTests
    {
        [Fact]
        public Task TestPoisonousWithDivineShield()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
play 0 0
end_turn
attack 0 0
attack 1 1
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.EmperorCobra, CardIds.ArgentSquire, CardIds.EmperorCobra,
                CardIds.ArgentSquire, CardIds.EmperorCobra, CardIds.ArgentSquire, CardIds.EmperorCobra
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }
    }
}
