using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Core.Enums
{
    public enum UIEventType : int
    {
        // ActionUIEvents
        ActionCompleted = 1,

        // GameMechanicsUIEvents
        PlayerGoingFirst = 2,
        StartTurn = 3,
        GameOver = 4,
        PlayCard = 5,
        SummonMinion = 6,
        Attack = 7,
        MinionDied = 8,
        CardBurned = 9,
        MinionReturnedToHand = 10,
        CardDiscarded = 11,

        // CardEffectUIEvents
        SecretRevealed = 12
    }
}
