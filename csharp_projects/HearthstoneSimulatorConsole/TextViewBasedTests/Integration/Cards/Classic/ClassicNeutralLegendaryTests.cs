﻿using HearthstoneGameModel.Cards.Implementations.Classic;
using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicNeutralLegendaryTests
    {
        [Fact]
        public Task TestBloodmageThalnos()
        {
            string actionText = @"play 0 0
end_turn
hero_power
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.BloodmageThalnos, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }
    }
}