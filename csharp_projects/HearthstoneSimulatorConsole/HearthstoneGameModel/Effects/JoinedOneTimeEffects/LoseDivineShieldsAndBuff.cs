using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.JoinedOneTimeEffects
{
    public class LoseDivineShieldsAndBuff : OneTimeEffect
    {
        SlotSelection _loseDivineShieldsSelection;
        SlotSelection _buffSelection;
        int _attackBuff;
        int _healthBuff;

        public LoseDivineShieldsAndBuff(SlotSelection loseDivineShieldsSelection, SlotSelection buffSelection, int attackBuff, int healthBuff)
        {
            _loseDivineShieldsSelection = loseDivineShieldsSelection;
            _buffSelection = buffSelection;
            _attackBuff = attackBuff;
            _healthBuff = healthBuff;

            if (attackBuff <= 0)
            {
                throw new ArgumentException("attack amount must be positive");
            }
            if (healthBuff <= 0)
            {
                throw new ArgumentException("health amount must be positive");
            }
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot)
        {
            // Lose DivineShields
            List<CardSlot> slotsToLoseDivineShields = _loseDivineShieldsSelection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<EffectManagerNode> divineShields = new List<EffectManagerNode>();

            if (slotsToLoseDivineShields.Count == 0)
            {
                return null;
            }

            foreach (CardSlot slot in slotsToLoseDivineShields)
            {
                foreach (EffectManagerNode emNode in slot.GetEMNodes())
                {
                    if (emNode.Effect.EffectType == EMEffectType.DivineShield)
                    {
                        divineShields.Add(emNode);
                        break;
                    }
                }
            }

            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.ToRemove.AddRange(divineShields);

            // Buff
            List<CardSlot> selectedCardSlots = _buffSelection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<EffectManagerNode> emNodesToAdd = new List<EffectManagerNode>();
            int attackAmountValue = _attackBuff * divineShields.Count;
            int healthAmountValue = _healthBuff * divineShields.Count;

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                EffectManagerNode newEmNode = new EffectManagerNode(
                    new Buff(attackAmountValue, healthAmountValue), selectedCardSlot, originCardSlot, true
                );
                emNodesToAdd.Add(newEmNode);
            }

            plan.ToAdd.AddRange(emNodesToAdd);
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new LoseDivineShieldsAndBuff(_loseDivineShieldsSelection.Copy(), _buffSelection.Copy(), _attackBuff, _healthBuff);
        }
    }
}
