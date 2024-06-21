using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralRareTests
    {
        [Fact]
        public Task TestAngryChicken()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
hero_power
select 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YoungPriestess, CardIds.AngryChicken, CardIds.YoungPriestess, CardIds.AngryChicken,
                CardIds.YoungPriestess, CardIds.AngryChicken, CardIds.YoungPriestess
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestBloodsailCorsair()
        {
            string actionText = @"hero_power
attack -1 -1
end_turn
play 0 0
hero_power
play 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodsailCorsair, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestYoungPriestess()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YoungPriestess, CardIds.Wisp, CardIds.YoungPriestess, CardIds.Wisp,
                CardIds.YoungPriestess, CardIds.Wisp, CardIds.YoungPriestess
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestLightwarden()
        {
            string actionText = @"hero_power
play 0 0
play 0 1
end_turn
hero_power
play 0 0
play 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.Lightwarden, CardIds.PriestessOfElune, CardIds.Lightwarden, CardIds.PriestessOfElune,
                CardIds.Lightwarden, CardIds.PriestessOfElune, CardIds.Lightwarden
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warlock);
            return Verify(log);
        }
    }
}
