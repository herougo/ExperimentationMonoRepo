using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Effects
{
    public class SilenceEffectTests
    {
        [Fact]
        public Task TestOpponentStealth()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
hero_power
select 0 0
select 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.WorgenInfiltrator, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestOwnStealth()
        {
            string actionText = @"play 0 0
hero_power
select 0 0
play 0 1
select 0 0
end_turn
hero_power
select 0 0
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.JunglePanther, CardIds.IronbeakOwl, CardIds.JunglePanther,
                CardIds.IronbeakOwl, CardIds.JunglePanther, CardIds.IronbeakOwl, CardIds.JunglePanther
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestDireWolfAlpha()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
select 0 1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.DireWolfAlpha, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestExternalDireWolfAlpha()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
select 0 2
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.Wisp, CardIds.DireWolfAlpha, CardIds.Wisp,
                CardIds.DireWolfAlpha, CardIds.Wisp, CardIds.DireWolfAlpha, CardIds.Wisp
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestTriggerFlesheatingGhoul()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
select 0 1
hero_power
select 0 2
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.Wisp, CardIds.FlesheatingGhoul, CardIds.Wisp,
                CardIds.FlesheatingGhoul, CardIds.Wisp, CardIds.FlesheatingGhoul, CardIds.Wisp
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestDeathrattleLeperGnome()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
hero_power
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.LeperGnome, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestTaunt()
        {
            string actionText = @"play 0 0
play 0 1
end_turn
play 0 0
select 0 0
play 0 1
select 0 1
hero_power
attack -1 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Shieldbearer, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestConditionalAmaniBerserker()
        {
            string actionText = @"play 0 0
hero_power
select 0 0
end_turn
play 0 0
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.AmaniBerserker, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestWindfury()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
end_turn
attack 0 -1
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.YoungDragonhawk, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestElusive()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
hero_power
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.FaerieDragon, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestDivineShield()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
hero_power
select 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ArgentSquire, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestTimeLimitedEffect()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
play 0 2
select 0 0
concede";
            List<string> cardIdList0 = new List<string> {
                CardIds.Wisp, CardIds.Wisp, CardIds.Wisp,
                CardIds.Wisp, CardIds.IronbeakOwl, CardIds.AbusiveSergeant, CardIds.AbusiveSergeant
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestSleep()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestFrozen()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
select 0 0
end_turn
attack 0 -1
play 0 1
select 0 0
attack 0 -1
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.IronbeakOwl, 30).ToList();
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FrostElemental, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }
    }
}
