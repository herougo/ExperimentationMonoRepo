using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
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

        public static int ComputePlayer(int player, PlayerChoice playerChoice)
        {
            switch (playerChoice)
            {
                case PlayerChoice.Player:
                    return player;
                case PlayerChoice.Opponent:
                    return 1 - player;
                case PlayerChoice.Both:
                    throw new ArgumentException("ComputePlayer cannot handle PlayerChoice.Both");
                default:
                    throw new NotImplementedException();
            }
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

        public static bool TargetableWithSpell(BattlerCardSlot slot, int playerDoingTargeting)
        {
            if (slot.HasStealth && playerDoingTargeting != slot.Player)
            {
                return false;
            }
            return !slot.HasElusive;
        }

        public static bool TargetableWithHeroPower(BattlerCardSlot slot, int playerDoingTargeting)
        {
            if (slot.HasStealth && playerDoingTargeting != slot.Player)
            {
                return false;
            }
            return !slot.HasElusive;
        }

        public static bool TargetableWithMinionEffect(BattlerCardSlot slot, int playerDoingTargeting)
        {
            if (slot.HasStealth && playerDoingTargeting != slot.Player)
            {
                return false;
            }
            return true;
        }
    }
}
