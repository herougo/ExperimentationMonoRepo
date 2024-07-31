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
using HearthstoneGameModel.Effects.OneTimeEffects;
using HearthstoneGameModel.Selections;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects
{
    public class SetRemainingHealth : OneTimeEffect
    {
        SlotSelection _selection;
        IIntValue _amount;

        public SetRemainingHealth(SlotSelection selection, int amount)
        {
            _selection = selection;
            _amount = new ConstIntValue(amount);
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public SetRemainingHealth(SlotSelection selection, IIntValue amount)
        {
            _selection = selection;
            _amount = amount;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<EffectManagerNode> emNodesToAdd = new List<EffectManagerNode>();
            int amountValue = _amount.Get(game, affectedCardSlot);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                BattlerCardSlot battlerCardSlot = (BattlerCardSlot)selectedCardSlot;
                if (battlerCardSlot.MaxHealth < amountValue)
                {
                    EffectManagerNode newEmNode = new EffectManagerNode(
                        new SetMaxHealth(amountValue), selectedCardSlot, originCardSlot, true
                    );
                    emNodesToAdd.Add(newEmNode);
                }

                battlerCardSlot.Health = amountValue;
                plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.SetHealth, battlerCardSlot));
            }

            if (emNodesToAdd.Count > 0)
            {
                plan.ToAdd.AddRange(emNodesToAdd);
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new SetRemainingHealth(_selection.Copy(), _amount);
        }
    }
}
