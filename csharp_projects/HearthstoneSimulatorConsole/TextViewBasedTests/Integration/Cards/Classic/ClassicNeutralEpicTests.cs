﻿using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralEpicTests
    {
        [Fact]
        public Task TestHungryCrab()
        {
            string actionText = @"play 0 0
play 0 1
select 0 0
play 0 1
end_turn
play 1 0
select 0 0
select 0 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.HungryCrab, CardIds.MurlocTidecaller, CardIds.HungryCrab, CardIds.MurlocTidecaller,
                CardIds.HungryCrab, CardIds.MurlocTidecaller, CardIds.HungryCrab, CardIds.MurlocTidecaller
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestDoomsayer()
        {
            string actionText = @"play 0 0
hero_power
end_turn
hero_power
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.Doomsayer, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestBloodKnight()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
play 0 3
hero_power
select 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.BloodKnight, CardIds.ArgentSquire, CardIds.BloodKnight, CardIds.ArgentSquire,
                CardIds.BloodKnight, CardIds.ArgentSquire, CardIds.MurlocTidecaller, CardIds.ArgentSquire
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestMurlocWarleader()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
play 0 3
select 0 2
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader,
                CardIds.HungryCrab, CardIds.MurlocWarleader, CardIds.MurlocTidecaller, CardIds.ArgentSquire
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestSouthseaCaptain()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.SouthseaCaptain, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestBigGameHunter()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
select 0 0
select 0 2
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader,
                CardIds.HungryCrab, CardIds.BloodKnight, CardIds.ArgentSquire, CardIds.ArgentSquire
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.BigGameHunter, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestFacelessManipulator()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
select 0 1
end_turn
play 0 0
select 0 0
end_turn
attack 2 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader, CardIds.MurlocWarleader,
                CardIds.MurlocWarleader, CardIds.FacelessManipulator, CardIds.MurlocWarleader, CardIds.ArgentSquire
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.FacelessManipulator, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Mage);
            return Verify(log);
        }

        [Fact]
        public Task TestSeaGiant()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
hero_power
end_turn
hero_power
play 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.SeaGiant, CardIds.SeaGiant, CardIds.SeaGiant, CardIds.SeaGiant,
                CardIds.SeaGiant, CardIds.ArgentSquire, CardIds.ArgentSquire, CardIds.ArgentSquire
            };
            List<string> cardIdList1 = Enumerable.Repeat(CardIds.SeaGiant, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList1, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}
