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
    public class WhileSelfDamaged : ICondition
    {
        List<string> _eventsReceived;

        public WhileSelfDamaged()
        {
            _eventsReceived = new List<string> { EffectEvent.DamageTaken, EffectEvent.CharacterHealed };
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
            CardSlot slot = emNode.AffectedSlot;
            BattlerCardSlot typedSlot = (BattlerCardSlot)slot;
            return typedSlot.Health < typedSlot.MaxHealth;
        }

        public ICondition Copy()
        {
            return new WhileSelfDamaged();
        }
    }
}
