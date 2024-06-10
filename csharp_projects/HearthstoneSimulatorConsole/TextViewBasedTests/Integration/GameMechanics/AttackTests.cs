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

        [Fact]
        public Task TestAttackedAlready()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string actionText = @"play 0 0
attack 0 -1
end_turn
end_turn
attack 0 -1
attack 0 -1
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }

        [Fact]
        public Task TestAttackedAlreadyWindfury()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.YoungDragonhawk, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string actionText = @"play 0 0
attack 0 -1
end_turn
end_turn
attack 0 -1
attack 0 -1
attack 0 -1
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }

        [Fact]
        public Task TestCharge()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.Wisp, 30).ToList();
            string actionText = @"play 0 0
attack 0 -1
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }

        [Fact]
        public Task TestDisobeyAndObeyTaunt()
        {
            List<string> cardIdList0 = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                cardIdList0.Add(CardIds.Shieldbearer);
                cardIdList0.Add(CardIds.Wisp);
            }
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
attack 0 -1
attack 0 0
attack 0 1
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }

        [Fact]
        public Task TestDisobeyStealth()
        {
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.StranglethornTiger, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.ArgentCommander, 30).ToList();
            string actionText = @"play 0 0
end_turn
play 0 0
attack 0 0
concede";
            string log = TestGameUtils.RunPaladinGame(actionText, cardIdList0, cardIdList1, true);
            return Verify(log);
        }
    }
}
