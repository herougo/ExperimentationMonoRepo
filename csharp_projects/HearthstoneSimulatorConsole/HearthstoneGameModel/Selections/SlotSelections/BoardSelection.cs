using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.Utils;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class BoardSelection : SlotSelection
    {
        PlayerChoice _playerChoice;

        public BoardSelection(PlayerChoice playerChoice)
        {
            _playerChoice = playerChoice;
            _eventsReceived = new List<string>
            {
                EffectEvent.MinionDies, EffectEvent.MinionPutInPlay, EffectEvent.CardMovedToHand
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            int refPlayer = cardSlot.Player;
            List<CardSlot> result = new List<CardSlot>();
            for (int player = 0; player < HearthstoneConstants.NumberOfPlayers; player++) {
                if (HSGameUtils.IsPlayerAffected(player, refPlayer, _playerChoice))
                {
                    result.AddRange(game.Battleboard.GetAllSlots(player));
                }
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new BoardSelection(_playerChoice);
        }
    }
}
