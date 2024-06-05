using HearthstoneGameModel.Game;
using HearthstoneGameModel.Utils;
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
        [Fact]
        public Task TestConcedeImmediately()
        {
            string actionText = "concede";
            return Verify(TestGameUtils.RunWispPaladinGame(actionText));
        }
    }
}
