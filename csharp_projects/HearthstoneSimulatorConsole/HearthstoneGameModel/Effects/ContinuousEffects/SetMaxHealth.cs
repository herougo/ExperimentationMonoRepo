using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class SetMaxHealth : ContinuousEffect
    {
        int _amount;

        public SetMaxHealth(int amount)
        {
            _amount = amount;
            _effectArea = EffectArea.All;
        }

        public override void AdjustStats(CardSlot cardSlot)
        {
            switch (cardSlot.CardType)
            {
                case CardType.Minion:
                case CardType.Hero:
                    BattlerCardSlot battlerCardSlot = (BattlerCardSlot)cardSlot;
                    battlerCardSlot.MaxHealth = _amount;
                    return;
            }
            throw new NotImplementedException("Invalid card type to adjust stats from SetMaxHealth");
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
            return new SetMaxHealth(_amount);
        }
    }
}
