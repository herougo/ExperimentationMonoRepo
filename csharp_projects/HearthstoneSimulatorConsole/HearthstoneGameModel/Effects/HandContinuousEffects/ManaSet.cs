using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.HandContinuousEffects
{
    public class ManaSet : ContinuousEffect
    {
        int _setValue;

        public ManaSet(int setValue)
        {
            _setValue = setValue;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            cardSlot.Mana = _setValue;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.UpdateStats.Add(emNode.AffectedSlot);
            return plan;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.UpdateStats.Add(emNode.AffectedSlot);
            return plan;
        }

        public override EMEffect Copy()
        {
            return new ManaSet(_setValue);
        }
    }
}
