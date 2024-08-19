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
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class Heal : OneTimeEffect
    {
        SlotSelection _selection;
        int _amount;

        public Heal(SlotSelection selection, int amount)
        {
            _selection = selection;
            _amount = amount;
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            EffectManagerNodePlan plan = new EffectManagerNodePlan();

            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                BattlerCardSlot typedCardSlot = (BattlerCardSlot)selectedCardSlot;
                typedCardSlot.Health = Math.Min(typedCardSlot.Health + _amount, typedCardSlot.MaxHealth);
                plan.UpdateStats.Add(selectedCardSlot);
                plan.EffectEventArgs.Add(new EffectEventArgs(EffectEvent.CharacterHealed, selectedCardSlot));
            }
            
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new Heal(_selection.Copy(), _amount);
        }
    }
}
