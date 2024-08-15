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
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Triggers
{
    public class OnTurnEnd : Trigger
    {
        PlayerChoice _playerChoice;

        public OnTurnEnd(PlayerChoice playerChoice)
        {
            _eventsReceived = new List<string> { EffectEvent.EndTurn };
            _playerChoice = playerChoice;
        }

        public OnTurnEnd()
        {
            _eventsReceived = new List<string> { EffectEvent.EndTurn };
            _playerChoice = PlayerChoice.Player;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            return HSGameUtils.IsPlayerAffected(emNode.AffectedSlot.Player, game.GameMetadata.Turn, _playerChoice);
        }

        public override Trigger Copy()
        {
            return new OnTurnEnd(_playerChoice);
        }
    }
}
