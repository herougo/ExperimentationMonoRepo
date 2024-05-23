using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.Utils
{
    public static class HSGameUtils
    {
        public static bool IsPlayerAffected(int player, int refPlayer, PlayerChoice playerChoice)
        {
            /* is player affected by refPlayer using playerChoice?
            Example: 0 affected by 1 using Opponent -> true
            */
            return (
                (playerChoice == PlayerChoice.Both) ||
                (playerChoice == PlayerChoice.Player && player == refPlayer) ||
                (playerChoice == PlayerChoice.Opponent && player != refPlayer)
            );
        }

        public static bool MatchesTag(MinionTag desiredTag, MinionTag actualTag)
        {
            return (
                (desiredTag == MinionTag.Any)
                || (actualTag == MinionTag.All)
                || (desiredTag == MinionTag.All)
                || (desiredTag == actualTag)
            );
        }
    }
}
