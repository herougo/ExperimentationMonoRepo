using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Triggers
{
    public class OnTurnStart : Trigger
    {
        PlayerChoice _playerChoice;

        public OnTurnStart(PlayerChoice playerChoice)
        {
            _eventsReceived = new List<string> { EffectEvent.StartTurn };
            _playerChoice = playerChoice;
        }

        public OnTurnStart()
        {
            _eventsReceived = new List<string> { EffectEvent.StartTurn };
            _playerChoice = PlayerChoice.Player;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            CardSlot affectedSlot, List<CardSlot> eventSlots)
        {
            return HSGameUtils.IsPlayerAffected(affectedSlot.Player, game.GameMetadata.Turn, _playerChoice);
        }

        public override Trigger Copy()
        {
            return new OnTurnStart(_playerChoice);
        }
    }
}
