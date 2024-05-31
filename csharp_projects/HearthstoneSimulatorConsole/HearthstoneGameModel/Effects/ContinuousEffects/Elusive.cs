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
    public class Elusive : ContinuousEffect
    {

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumElusive += 1;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumElusive -= 1;
            if (typedSlot.NumElusive < 0)
            {
                throw new AssertionException("NumElusive < 0");
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Elusive();
        }
    }
}
