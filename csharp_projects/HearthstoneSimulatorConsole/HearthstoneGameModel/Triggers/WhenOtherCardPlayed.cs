﻿using HearthstoneGameModel.Core.Enums;
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
    public class WhenOtherCardPlayed : Trigger
    {
        PlayerChoice _playerMatch;

        public WhenOtherCardPlayed(PlayerChoice playerMatch)
        {
            _eventsReceived = new List<string> { EffectEvent.WhenCardPlayed };
            _playerMatch = playerMatch;
        }

        public override bool ShouldRun(
            string effectEvent, HearthstoneGame game,
            CardSlot affectedSlot, List<CardSlot> eventSlots)
        {
            if (eventSlots[0] == affectedSlot)
            {
                return false;
            }
            int eventPlayer = eventSlots[0].Player;
            int effectPlayer = affectedSlot.Player;

            if (!HSGameUtils.IsPlayerAffected(effectPlayer, eventPlayer, _playerMatch))
            {
                return false;
            }
            return true;
        }

        public override Trigger Copy()
        {
            return new WhenOtherCardPlayed(_playerMatch);
        }
    }
}
