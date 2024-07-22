using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class ChangeStats : OneTimeEffect
    {
        SlotSelection _selection;
        IIntValue _attackAmount;
        IIntValue _healthAmount;

        public ChangeStats(SlotSelection selection, int attackAmount, int healthAmount) {
            _selection = selection;
            _attackAmount = new ConstIntValue(attackAmount);
            _healthAmount = new ConstIntValue(healthAmount);
            if (attackAmount <= 0)
            {
                throw new ArgumentException("attack amount must be positive");
            }
            if (healthAmount <= 0)
            {
                throw new ArgumentException("health amount must be positive");
            }
        }

        public ChangeStats(SlotSelection selection, IIntValue attackAmount, IIntValue healthAmount)
        {
            _selection = selection;
            _attackAmount = attackAmount;
            _healthAmount = healthAmount;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<EffectManagerNode> emNodesToAdd = new List<EffectManagerNode>();
            int attackAmountValue = _attackAmount.Get(game, affectedCardSlot);
            int healthAmountValue = _healthAmount.Get(game, affectedCardSlot);

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                EffectManagerNode newEmNode = new EffectManagerNode(
                    new Buff(attackAmountValue, healthAmountValue), selectedCardSlot, originCardSlot, true
                );
                emNodesToAdd.Add(newEmNode);
            }

            if (emNodesToAdd.Count > 0)
            {
                EffectManagerNodePlan plan = new EffectManagerNodePlan();
                plan.ToAdd.AddRange(emNodesToAdd);
                return plan;
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new ChangeStats(_selection.Copy(), _attackAmount, _healthAmount);
        }
    }
}
