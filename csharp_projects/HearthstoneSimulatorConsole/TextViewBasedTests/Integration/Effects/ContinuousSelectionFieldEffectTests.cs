using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class ContinuousSelectionFieldEffectTests
    {
        [Fact]
        public Task TestMovingExternalEffectToHand()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
select 0 1
play 1 0
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.Wisp, CardIds.FrostElemental, CardIds.Wisp,
                CardIds.FrostElemental, CardIds.YouthfulBrewmaster, CardIds.Wisp, CardIds.DireWolfAlpha
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }


        [Fact]
        public Task TestSpitefulSmithWithDreadCorsair()
        {
            string actionText = @"play 0 0
hero_power
end_turn
hero_power
attack -1 0
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.SpitefulSmith, CardIds.DreadCorsair, CardIds.SpitefulSmith,
                CardIds.DreadCorsair, CardIds.SpitefulSmith, CardIds.DreadCorsair, CardIds.SpitefulSmith
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }
    }
}
