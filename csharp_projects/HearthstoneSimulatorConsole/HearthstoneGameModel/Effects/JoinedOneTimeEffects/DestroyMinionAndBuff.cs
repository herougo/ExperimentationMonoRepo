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
    public class DestroyMinionAndBuff : OneTimeEffect
    {
        SlotSelection _destroySelection;
        SlotSelection _buffSelection;
        int _attackBuff;
        int _healthBuff;

        public DestroyMinionAndBuff(SlotSelection destroySelection, SlotSelection buffSelection, int attackBuff, int healthBuff)
        {
            _destroySelection = destroySelection;
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

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            // Destroy
            List<CardSlot> slotsToDestroy = _destroySelection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);

            if (slotsToDestroy.Count == 0)
            {
                return null;
            }

            foreach (CardSlot slot in slotsToDestroy)
            {
                ((MinionCardSlot)slot).IsDestroyed = true;
            }

            // Buff
            List<CardSlot> selectedCardSlots = _buffSelection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            List<EffectManagerNode> emNodesToAdd = new List<EffectManagerNode>();
            int attackAmountValue = _attackBuff;
            int healthAmountValue = _healthBuff;

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
            return new DestroyMinionAndBuff(_destroySelection.Copy(), _buffSelection.Copy(), _attackBuff, _healthBuff);
        }
    }
}
