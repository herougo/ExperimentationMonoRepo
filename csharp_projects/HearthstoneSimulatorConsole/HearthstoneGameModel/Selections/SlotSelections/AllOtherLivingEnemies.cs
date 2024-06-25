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
    public class AllOtherLivingEnemies : SlotSelection
    {
        public AllOtherLivingEnemies()
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
            int enemyPlayer = 1 - cardSlot.Player;
            List<CardSlot> result = new List<CardSlot> { game.Players[enemyPlayer] };
            
            foreach (CardSlot slot in game.Battleboard.GetAllSlots(enemyPlayer))
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
                result.Add(slot);
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new AllOtherLivingEnemies();
        }
    }
}
