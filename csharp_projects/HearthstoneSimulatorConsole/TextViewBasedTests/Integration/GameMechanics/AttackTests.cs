using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.GameMechanics
{
    public class AttackTests
    {
        /*
        - [x] Zero Attack
        - [x] Frozen
        - [ ] Asleep
        - [ ] Already Attacked
        - [ ] Already Attacked Twice with Windfury
        - [ ] Charge
        - [ ] Disobey Taunt
        - [ ] Obey Taunt
         */

        [Fact]
        public Task TestZeroAttack()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Shieldbearer, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Shieldbearer, 30).ToList();
            string actionText = @"play 0 0
end_turn
play 0 0
end_turn
attack 0 0
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, false);
            return Verify(log);
        }

        [Fact]
        public Task TestFrozen()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FrostElemental, 30).ToList();
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
end_turn
attack 0 0
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }

        [Fact]
        public Task TestAsleep()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string actionText = @"play 0 0
attack 0 -1
end_turn
play 0 0
end_turn
attack 0 0
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }
    }
}
