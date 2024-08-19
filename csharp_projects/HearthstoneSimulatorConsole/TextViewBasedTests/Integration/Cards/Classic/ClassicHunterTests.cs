using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicHunterTests
    {
        [Fact]
        public Task TestExplosiveTrap()
        {
            string actionText = @"play 1 0
play 1 1
end_turn
play 1 0
play 1 1
play 1 2
end_turn
play 0
attack 0 -1
end_turn
attack 1 0
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.BloodKnight, CardIds.BloodKnight, CardIds.AngryChicken, CardIds.ExplosiveTrap
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }
    }
}
