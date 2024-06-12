using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class DealDamage : OneTimeEffect
    {
        SlotSelection _selection;
        int _amount;

        public DealDamage(SlotSelection selection, int amount)
        {
            _selection = selection;
            _amount = amount;
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                BattlerCardSlot typedCardSlot = (BattlerCardSlot)selectedCardSlot;
                plan.Update(typedCardSlot.TakeDamage(_amount));
            }

            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new DealDamage(_selection.Copy(), _amount);
        }
    }
}
