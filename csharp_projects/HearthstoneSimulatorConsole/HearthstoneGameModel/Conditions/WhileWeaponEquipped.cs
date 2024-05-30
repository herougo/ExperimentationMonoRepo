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
    public class WhileWeaponEquipped : ICondition
    {
        List<string> _eventsReceived;

        public WhileWeaponEquipped()
        {
            _eventsReceived = new List<string> { 
                EffectEvent.WeaponEquipped, EffectEvent.WeaponDestroyed
            };
        }

        public List<string> EventsReceived
        {
            get
            {
                return _eventsReceived;
            }
        }

        public bool Evaluate(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            return game.Weapons[player] != null;
        }

        public ICondition Copy()
        {
            return new WhileWeaponEquipped();
        }
    }
}
