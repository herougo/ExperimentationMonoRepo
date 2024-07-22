using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects.HandContinuousEffects
{
    public class ManaChange : ContinuousEffect
    {
        IIntValue _amount;
        int _multiplier;

        public ManaChange(IIntValue amount, int multiplier)
        {
            _amount = amount;
            _multiplier = multiplier;
            _isHandEffect = true;
        }

        public ManaChange(int amount, int multiplier)
        {
            _amount = new ConstIntValue(amount);
            _multiplier = multiplier;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            int change = _amount.Get(cardSlot.Game, cardSlot);
            cardSlot.Mana += change * _multiplier;
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
            return new ManaChange(_amount, _multiplier);
        }
    }
}
