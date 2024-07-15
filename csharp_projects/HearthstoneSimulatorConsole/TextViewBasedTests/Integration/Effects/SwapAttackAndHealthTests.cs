using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class SwapAttackAndHealthTests
    {
        [Fact]
        public Task Test4_2()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
play 1 2
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander, CardIds.CrazedAlchemist,
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task Test4_2_ThenSilence()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander, CardIds.CrazedAlchemist,
                CardIds.ArgentCommander, CardIds.CrazedAlchemist, CardIds.ArgentCommander
            };
            List<string> cardIdList1 = new List<string>
            {
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl,
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task Test23_ThenSilence()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.BloodsailRaider, CardIds.CrazedAlchemist, CardIds.BloodsailRaider, CardIds.CrazedAlchemist,
                CardIds.BloodsailRaider, CardIds.CrazedAlchemist, CardIds.BloodsailRaider
            };
            List<string> cardIdList1 = new List<string>
            {
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl,
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }



        [Fact]
        public Task TestZeroAttack()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.Shieldbearer, CardIds.CrazedAlchemist, CardIds.Shieldbearer, CardIds.CrazedAlchemist,
                CardIds.Shieldbearer, CardIds.CrazedAlchemist, CardIds.Shieldbearer
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task Test23_Damage_ThenSilence()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
hero_power
select 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.BloodsailRaider, CardIds.CrazedAlchemist, CardIds.BloodsailRaider, CardIds.CrazedAlchemist,
                CardIds.BloodsailRaider, CardIds.CrazedAlchemist, CardIds.BloodsailRaider
            };
            List<string> cardIdList1 = new List<string>
            {
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl,
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestSouthseaCaptainSwap()
        {
            string actionText = @"play 0 0
play 1 1
play 0 2
select 0 0
end_turn
play 0 0
select 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.SouthseaCaptain, CardIds.CrazedAlchemist, CardIds.SouthseaCaptain, CardIds.CrazedAlchemist,
                CardIds.SouthseaCaptain, CardIds.CrazedAlchemist, CardIds.SouthseaCaptain
            };
            List<string> cardIdList1 = new List<string>
            {
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl,
                CardIds.IronbeakOwl, CardIds.IronbeakOwl, CardIds.IronbeakOwl
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }
    }
}
