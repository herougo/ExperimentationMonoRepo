using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextViewBasedTests.Utils;

namespace TextViewBasedTests.Integration.Cards.Classic
{
    public class ClassicHunterTests
    {
        [Fact]
        public Task TestExplosiveTrap()
        {
            string actionText = @"play 1 0
play 1 1
end_turn
play 1 0
play 1 1
play 1 2
end_turn
play 0
attack 0 -1
end_turn
attack 1 0
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.BloodKnight, CardIds.BloodKnight, CardIds.AngryChicken, CardIds.ExplosiveTrap
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestFreezingTrap()
        {
            string actionText = @"hero_power
play 0
play 0 0
attack -1 -1
end_turn
play 0
play 0 0
end_turn
attack 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.BloodKnight, CardIds.BloodKnight, CardIds.BloodKnight, CardIds.FreezingTrap
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Rogue);
            return Verify(log);
        }

        [Fact]
        public Task TestSnipe()
        {
            string actionText = @"play 0
play 0 0
end_turn
play 1 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.BloodKnight, CardIds.BloodKnight, CardIds.CairneBloodhoof, CardIds.Snipe
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestScavengingHyena()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 0 0
play 0 1
play 0 2
end_turn
attack 2 2
attack 1 1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.ScavengingHyena, CardIds.ScavengingHyena
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestDeadlyShot()
        {
            string actionText = @"play 2 0
play 2 1
end_turn
play 0
play 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.ScavengingHyena, CardIds.DeadlyShot, CardIds.DeadlyShot
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestUnleashTheHounds()
        {
            string actionText = @"play 0 0
play 0 1
play 0 2
end_turn
play 3
attack 0 -1
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.UnleashTheHounds, CardIds.ScavengingHyena, CardIds.AngryChicken, CardIds.AngryChicken
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestFlare()
        {
            string actionText = @"play 0 0
play 0
end_turn
play 0 0
play 0
end_turn
play 0
attack 0 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.Flare, CardIds.Flare, CardIds.ExplosiveTrap, CardIds.WorgenInfiltrator
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }

        [Fact]
        public Task TestEaglehornBow()
        {
            string actionText = @"play 0
play 0
end_turn
play 0
play 1 0
concede";
            List<string> cardIdList0 = new List<string>
            {
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken, CardIds.AngryChicken,
                CardIds.AngryChicken, CardIds.AngryChicken, CardIds.Snipe, CardIds.EaglehornBow
            };
            string log = TestGameUtils.RunGame(actionText, cardIdList0, cardIdList0, true, CardIds.Hunter);
            return Verify(log);
        }
    }
}
