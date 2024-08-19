using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SwapAttackAndHealth : OneTimeEffect
    {
        SlotSelection _selection;

        public SwapAttackAndHealth(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot slot in selectedCardSlots)
            {
                BattlerCardSlot battlerCardSlot = (BattlerCardSlot)slot;
                int originalAttack = battlerCardSlot.Attack;
                int originalHealth = battlerCardSlot.Health;

                EffectManagerNode newAttackEmNode = new EffectManagerNode(
                    new SetAttack(originalHealth), battlerCardSlot, originCardSlot, true
                );
                plan.ToAdd.Add(newAttackEmNode);

                EffectManagerNode newMaxHealthEmNode = new EffectManagerNode(
                    new SetMaxHealth(originalAttack), battlerCardSlot, originCardSlot, true
                );
                plan.ToAdd.Add(newMaxHealthEmNode);

                plan.UpdateStats.Add(slot);

                plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.SetHealth, battlerCardSlot));
            }

            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new SwapAttackAndHealth(_selection.Copy());
        }
    }
}
