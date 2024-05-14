using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public static class UIEvent
    {
        public const string ActionCompleted = "action_completed";
        public const string StartTurn = "start_turn";
        public const string EndTurnSelected = "end_turn_selected";
        public const string GameOver = "game_over";
    }
}
