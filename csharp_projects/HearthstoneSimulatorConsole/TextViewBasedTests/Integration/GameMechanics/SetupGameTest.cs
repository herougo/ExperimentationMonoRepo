using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextView;
using TextViewBasedTests.Utils;


namespace TextViewBasedTests.Integration.GameMechanics
{
    public class SetupGameTest
    {
        Task TestHSGame(string actionText)
        {
            ListTextLogger logger = new ListTextLogger();
            HearthstoneGame game = GameBuilders.BuildWispPaladinGame(actionText, logger);
            game.SetupGame(false);
            game.Play();
            return Verify(logger.GetLog());
        }

        [Fact]
        public Task TestConcedeImmediately()
        {
            string actionText = "concede";
            return TestHSGame(actionText);
        }
    }
}
