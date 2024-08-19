using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.Utils;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class HandSelection : SlotSelection
    {
        PlayerChoice _playerChoice;

        public HandSelection(PlayerChoice playerChoice) {
            _playerChoice = playerChoice;
            _eventsReceived = new List<string>
            {
                EffectEvent.CardPlayed, EffectEvent.CardMovedToHand
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            int refPlayer = cardSlot.Player;
            List<CardSlot> result = new List<CardSlot>();
            for (int player = 0; player < HearthstoneConstants.NumberOfPlayers; player++)
            {
                if (!HSGameUtils.IsPlayerAffected(player, refPlayer, _playerChoice))
                {
                    continue;
                }

                foreach (CardSlot handCardSlot in game.Hands[player])
                {
                    result.Add(handCardSlot);
                }
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new HandSelection(_playerChoice);
        }
    }
}
