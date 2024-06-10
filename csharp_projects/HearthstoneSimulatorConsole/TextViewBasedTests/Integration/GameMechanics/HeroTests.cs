using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.GameMechanics
{
    public class HeroTests
    {
        /*
         * Priest
         * Rogue
         * Druid
         * Shaman
         * Warlock
         * Paladin
         * Warrior
         * Hunter
         * Mage
         * Demon Hunter
         */
        [Fact]
        public Task TestPriest()
        {
            string actionText = @"play 0 0
attack 0 -1
end_turn
hero_power
select 1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Priest);
            return Verify(log);
        }


        [Fact]
        public Task TestRogue()
        {
            string actionText = @"hero_power
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }
    }
}
