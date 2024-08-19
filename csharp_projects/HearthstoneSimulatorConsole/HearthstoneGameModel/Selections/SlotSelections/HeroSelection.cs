using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class HeroSelection : SlotSelection
    {
        PlayerChoice _playerChoice;

        public HeroSelection(PlayerChoice playerChoice)
        {
            _playerChoice = playerChoice;
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
                if (HSGameUtils.IsPlayerAffected(player, refPlayer, _playerChoice))
                {
                    result.Add(game.Players[player]);
                }
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new HeroSelection(_playerChoice);
        }
    }
}
