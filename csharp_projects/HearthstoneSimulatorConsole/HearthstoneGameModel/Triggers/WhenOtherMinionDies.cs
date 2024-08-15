using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Triggers
{
    public class WhenOtherMinionDies : Trigger
    {
        PlayerChoice _playerChoice;

        public WhenOtherMinionDies(PlayerChoice playerChoice)
        {
            _eventsReceived = new List<string> { EffectEvent.MinionDies };
            _playerChoice = playerChoice;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            return (
                HSGameUtils.IsPlayerAffected(emNode.AffectedSlot.Player, eventSlots[0].Player, _playerChoice)
                && eventSlots[0] != emNode.AffectedSlot
            );
        }

        public override Trigger Copy()
        {
            return new WhenOtherMinionDies(_playerChoice);
        }
    }
}
