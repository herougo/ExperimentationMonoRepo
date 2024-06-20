using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class FreezeEffectTests
    {
        [Fact]
        public Task TestAlreadyAttackedThenFrozen()
        {
            string actionText = @"play 0 0
end_turn
end_turn
attack 0 -1
play 0 1
select 0 0
end_turn
end_turn
attack 0 -1
end_turn
end_turn
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.Wisp, CardIds.FrostElemental, CardIds.Wisp,
                CardIds.FrostElemental, CardIds.Wisp, CardIds.FrostElemental, CardIds.Wisp
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestAlreadyAttackedOnceWindfuryThenFrozen()
        {
            string actionText = @"play 0 0
end_turn
end_turn
attack 0 -1
play 0 1
select 0 0
end_turn
end_turn
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.YoungDragonhawk, CardIds.FrostElemental, CardIds.YoungDragonhawk,
                CardIds.FrostElemental, CardIds.YoungDragonhawk, CardIds.FrostElemental, CardIds.YoungDragonhawk
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }
    }
}
