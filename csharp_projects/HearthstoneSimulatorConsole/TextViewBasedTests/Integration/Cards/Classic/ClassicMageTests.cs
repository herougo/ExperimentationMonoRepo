using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicMageTests
    {
        [Fact]
        public Task TestManaWyrm()
        {
            string actionText = @"play 0 0
play 0
play 0
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.Snipe, CardIds.ExplosiveTrap, CardIds.ManaWyrm
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestSorcerersApprentice()
        {
            string actionText = @"play 0 0
play 0
play 0
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.Snipe, CardIds.ExplosiveTrap, CardIds.SorcerersApprentice
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }
    }
}
