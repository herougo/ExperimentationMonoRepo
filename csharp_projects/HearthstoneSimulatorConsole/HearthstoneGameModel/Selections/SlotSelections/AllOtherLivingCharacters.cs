using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class AllOtherLivingCharacters : SlotSelection
    {
        public AllOtherLivingCharacters()
        {
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
            List<CardSlot> result = game.Players.ToList<CardSlot>();
            for (int player = 0; player < HearthstoneConstants.NumberOfPlayers; player++)
            {
                foreach (CardSlot slot in game.Battleboard.GetAllSlots(player))
                {
                    if (slot.CardType == CardType.Minion
                        || slot.CardType == CardType.Hero)
                    {
                        BattlerCardSlot battlerCardSlot = (BattlerCardSlot)slot;
                        if (battlerCardSlot.Health <= 0)
                        {
                            continue;
                        }
                    }
                    if (slot != cardSlot)
                    {
                        result.Add(slot);
                    }
                }
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllOtherLivingCharacters();
        }
    }
}
