﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class AllOtherFriendlyCharacters : SlotSelection
    {
        public AllOtherFriendlyCharacters()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            int player = cardSlot.Player;
            CardSlot playerSlot = game.Players[player];
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            result.Add(playerSlot);
            result.Remove(cardSlot);
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllOtherFriendlyCharacters();
        }
    }
}