﻿using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Sleep : ContinuousEffect
    {
        public Sleep() {
            _eventsReceived = new List<string> { EffectEvent.EndTurn };
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot slot = (BattlerCardSlot)emNode.AffectedSlot;
            slot.HasSleep = true;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot slot = (BattlerCardSlot)emNode.AffectedSlot;
            slot.HasSleep = false;
            return null;
        }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            CheckValidEvent(effectEvent);
            EffectManagerNodePlan result = new EffectManagerNodePlan();
            result.ToRemove.Add(emNode);
            return result;
        }

        public override EMEffect Copy()
        {
            return new Sleep();
        }
    }
}
