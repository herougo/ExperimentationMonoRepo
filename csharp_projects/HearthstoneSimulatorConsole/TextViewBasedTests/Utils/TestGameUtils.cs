using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextView;

namespace TextViewBasedTests.Utils
{
    public static class TestGameUtils
    {
        public static string RunWispPaladinGame(string actionText)
        {
            ListTextLogger logger = new ListTextLogger();
            HearthstoneGame game = GameBuilders.BuildWispPaladinGame(actionText, logger);
            game.SetupGame(false, false);
            game.Play();
            return logger.GetLog();
        }

        public static string RunPaladinGame(
            string actionText, List<string> cardIdList0, List<string> cardIdList1, bool maxMana
        )
        {
            ListTextLogger logger = new ListTextLogger();
            HearthstoneGame game = GameBuilders.BuildPaladinGame(
                actionText, logger, cardIdList0, cardIdList1
            );
            game.SetupGame(false, false);
            if (maxMana)
            {
                game.Players[0].AvailableMana = 10;
                game.Players[1].AvailableMana = 10;
            }
            game.Play();
            return logger.GetLog();
        }

        public static string RunGame(
            string actionText, List<string> cardIdList0, List<string> cardIdList1,
            bool maxMana, string hsClass
        )
        {
            ListTextLogger logger = new ListTextLogger();
            HearthstoneGame game = GameBuilders.BuildGame(
                actionText, logger, cardIdList0, cardIdList1, hsClass
            );
            game.SetupGame(false, false);
            if (maxMana)
            {
                game.Players[0].AvailableMana = 10;
                game.Players[1].AvailableMana = 10;
            }
            game.Play();
            return logger.GetLog();
        }
    }
}
