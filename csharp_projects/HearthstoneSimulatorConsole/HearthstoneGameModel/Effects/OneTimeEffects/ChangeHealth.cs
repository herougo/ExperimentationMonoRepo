using HearthstoneGameModel.Effects.ContinuousEffects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class ChangeHealth : OneTimeEffect
    {
        SlotSelection _selection;
        IIntValue _amount;

        public ChangeHealth(SlotSelection selection, int amount)
        {
            _selection = selection;
            _amount = new ConstIntValue(amount);
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public ChangeHealth(SlotSelection selection, IIntValue amount)
        {
            _selection = selection;
            _amount = amount;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<EffectManagerNode> emNodesToAdd = new List<EffectManagerNode>();
            int amountValue = _amount.Get(game, affectedCardSlot);

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                EffectManagerNode newEmNode = new EffectManagerNode(
                    new BuffHealth(amountValue), selectedCardSlot, originCardSlot, true
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
            return new ChangeHealth(_selection.Copy(), _amount);
        }
    }
}
