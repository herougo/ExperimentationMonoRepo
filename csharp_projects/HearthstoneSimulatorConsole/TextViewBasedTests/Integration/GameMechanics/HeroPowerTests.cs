using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.GameMechanics
{
    public class HeroPowerTests
    {
        [Fact]
        public Task TestNotEnoughMana()
        {
            string actionText = @"hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, false, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestHeroPowerAlreadyUsed()
        {
            string actionText = @"hero_power
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, false, CardIds.DemonHunter);
            return Verify(log);
        }

        [Fact]
        public Task TestHeroPowerRefreshNextTurn()
        {
            string actionText = @"hero_power
end_turn
end_turn
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, false, CardIds.DemonHunter);
            return Verify(log);
        }
    }
}
