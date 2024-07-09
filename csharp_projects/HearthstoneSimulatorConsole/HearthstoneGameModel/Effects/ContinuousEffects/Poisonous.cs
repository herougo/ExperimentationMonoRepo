using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Poisonous : ContinuousEffect
    {
        public Poisonous() {
            _eventsReceived = new List<string> { }; // TODO
            _requiresSlotMatchForEvent = true;
        }

        public override EffectManagerNodePlan SendEvent(string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            // TODO: 
            return null;
        }

        public override EMEffect Copy()
        {
            return new Poisonous();
        }
    }
}
