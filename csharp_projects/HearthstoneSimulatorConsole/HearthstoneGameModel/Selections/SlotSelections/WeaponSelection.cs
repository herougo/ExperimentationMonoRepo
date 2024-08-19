using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Selections.SlotSelections
{
    public class WeaponSelection : SlotSelection
    {
        bool _opposing;

        public WeaponSelection(bool opposing) {
            _opposing = opposing;
            _eventsReceived = new List<string>
            {
                EffectEvent.WeaponDestroyed, EffectEvent.WeaponEquipped
            };
        }

        public override List<CardSlot> GetSelectedCardSlots(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            CardSlot cardSlot = affectedCardSlot;
            int player = cardSlot.Player;
            if (_opposing)
            {
                player = 1 - player;
            }
            List<CardSlot> result = new List<CardSlot>();
            if (game.Weapons[player] != null)
            {
                result.Add(game.Weapons[player]);
            }
            return result;
        }

        public override SlotSelection Copy()
        {
            return new WeaponSelection(_opposing);
        }
    }
}
