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
    public class Charge : ContinuousEffect
    {
        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumCharge += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumCharge -= 1;
            if (typedSlot.NumCharge < 0)
            {
                throw new AssertionException("NumCharge < 0");
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Charge();
        }
    }
}
