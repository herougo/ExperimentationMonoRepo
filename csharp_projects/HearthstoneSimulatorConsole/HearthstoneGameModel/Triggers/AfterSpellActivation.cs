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
    public class AfterSpellActivation : Trigger
    {
            PlayerChoice _playerChoice;

            public AfterSpellActivation(PlayerChoice playerChoice)
            {
                _eventsReceived = new List<string> { EffectEvent.AfterSpellActivated };
                _playerChoice = playerChoice;
            }

            public override bool ShouldRun(
                string effectEvent, HearthstoneGame game,
                EffectManagerNode emNode, List<CardSlot> eventSlots)
            {
                return HSGameUtils.IsPlayerAffected(emNode.AffectedSlot.Player, eventSlots[0].Player, _playerChoice);
            }

            public override Trigger Copy()
            {
                return new AfterSpellActivation(_playerChoice);
            }
        
    }
}
