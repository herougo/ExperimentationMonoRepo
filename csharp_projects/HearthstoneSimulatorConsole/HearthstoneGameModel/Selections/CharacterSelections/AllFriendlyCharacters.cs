﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class AllFriendlyCharacters : CharacterSelection
    {
        public AllFriendlyCharacters() {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            CardSlot playerSlot = game.Players[player];
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            result.Add(playerSlot);
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AllFriendlyCharacters();
        }
    }
}