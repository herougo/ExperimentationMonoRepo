using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class ContinuousEffect : EventBasedEffect
    {
        public abstract EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode);

        public EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            return null;
        }

        public abstract ContinuousEffect Copy();
    }
}
