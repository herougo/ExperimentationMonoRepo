using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Triggers
{
    public class WhenSecretRevealed : Trigger
    {
        PlayerChoice _playerMatch;

        public WhenSecretRevealed(PlayerChoice playerMatch)
        {
            _eventsReceived = new List<string>{ EffectEvent.SecretRevealed };
            _playerMatch = playerMatch;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game, CardSlot affectedSlot, List<CardSlot> eventSlots
        )
        {
            return HSGameUtils.IsPlayerAffected(affectedSlot.Player, eventSlots[0].Player, _playerMatch);
        }

        public override Trigger Copy()
        {
            return new WhenSecretRevealed(_playerMatch);
        }
    }
}
