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
    public class ManaDiscount : ContinuousEffect
    {
        IIntValue _amount;

        public ManaDiscount(IIntValue amount)
        {
            _amount = amount;
            _isHandEffect = true;
        }

        public ManaDiscount(int amount)
        {
            _amount = new ConstIntValue(amount);
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            int discount = _amount.Get(cardSlot.Game, cardSlot);
            cardSlot.Mana -= discount;
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
            return new ManaDiscount(_amount);
        }
    }
}
