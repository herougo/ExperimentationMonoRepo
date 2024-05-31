using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Windfury : ContinuousEffect
    {
        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumWindfury += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumWindfury -= 1;
            if (typedSlot.NumWindfury < 0)
            {
                throw new AssertionException("NumWindfury < 0");
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Windfury();
        }
    }
}
