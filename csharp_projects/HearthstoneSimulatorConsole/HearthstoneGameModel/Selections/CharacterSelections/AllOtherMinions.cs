﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class AllOtherMinions : CharacterSelection
    {
        public AllOtherMinions()
        {
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            CardSlot cardSlot = emNode.AffectedSlot;
            int player = cardSlot.Player;
            List<CardSlot> result = game.Battleboard.GetAllSlots(player);
            if (cardSlot.CardType == CardType.Minion)
            {
                result.Remove(cardSlot);
            }
            result.AddRange(game.Battleboard.GetAllSlots(1 - player));
            return result;
        }

        public override CharacterSelection Copy()
        {
            return new AllOtherMinions();
        }
    }
}