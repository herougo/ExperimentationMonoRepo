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

        [Fact]
        public Task TestMurlocTidecaller()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
play 0 3
hero_power
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.MurlocTidecaller, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestAncientWatcher()
        {
            string actionText = @"play 0 0
end_turn
end_turn
attack 0 -1
play 0 1
select 0 0
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AncientWatcher, CardIds.IronbeakOwl, CardIds.AncientWatcher, CardIds.IronbeakOwl,
                CardIds.AncientWatcher, CardIds.IronbeakOwl, CardIds.AncientWatcher
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestKnifeJuggler()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
hero_power
play 0 2
play 0 3
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.KnifeJuggler, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestManaAddict()
        {
            string actionText = @"play 0 0
end_turn
play 0 0
play 3
end_turn
concede";
            List<string> cardIdList0 = Enumerable.Repeat(CardIds.ManaAddict, 30).ToList();
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Paladin);
            return Verify(log);
        }

        [Fact]
        public Task TestManaWraith()
        {
            string actionText = @"play 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.YouthfulBrewmaster, CardIds.ManaWraith, CardIds.YouthfulBrewmaster,
                CardIds.YouthfulBrewmaster, CardIds.Wisp, CardIds.ManaWraith
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Warlock);
            return Verify(log);
        }
    }
}
