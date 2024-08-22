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
    public class WhileSelfDamaged : Condition
    {
        public WhileSelfDamaged()
        {
            _eventsReceived = new List<string> { EffectEvent.DamageTaken, EffectEvent.CharacterHealed, EffectEvent.SetHealth };
        }

        public override bool Evaluate(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            CardSlot slot = emNode.AffectedSlot;
            BattlerCardSlot typedSlot = (BattlerCardSlot)slot;
            return typedSlot.Health < typedSlot.MaxHealth;
        }

        public override Condition Copy()
        {
            return new WhileSelfDamaged();
        }
    }
}
