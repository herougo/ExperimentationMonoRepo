using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Core;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class Taunt : ContinuousEffect
    {
        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumTaunt += 1;
            if (typedSlot.NumTaunt == 1)
            {
                game.Battleboard.AddTaunt(emNode.AffectedSlot);
            }
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            BattlerCardSlot typedSlot = (BattlerCardSlot)emNode.AffectedSlot;
            typedSlot.NumTaunt -= 1;
            if (typedSlot.NumTaunt < 0)
            {
                throw new AssertionException("NumTaunt < 0");
            }
            if (typedSlot.NumTaunt == 0)
            {
                game.Battleboard.RemoveTaunt(emNode.AffectedSlot);
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new Taunt();
        }
    }
}
