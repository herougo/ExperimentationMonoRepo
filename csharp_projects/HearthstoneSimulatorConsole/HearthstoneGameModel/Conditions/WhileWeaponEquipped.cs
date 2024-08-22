using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Conditions
{
    public class WhileWeaponEquipped : Condition
    {
        public WhileWeaponEquipped()
        {
            _eventsReceived = new List<string> { 
                EffectEvent.WeaponEquipped, EffectEvent.WeaponDestroyed
            };
        }

        public override bool Evaluate(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            int player = emNode.AffectedSlot.Player;
            return game.Weapons[player] != null;
        }

        public override Condition Copy()
        {
            return new WhileWeaponEquipped();
        }
    }
}
