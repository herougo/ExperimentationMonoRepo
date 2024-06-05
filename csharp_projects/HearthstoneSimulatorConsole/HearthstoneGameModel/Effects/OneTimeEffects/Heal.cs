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

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            
            foreach (CardSlot selectedCardSlot in selectedCardSlots)
            {
                BattlerCardSlot typedCardSlot = (BattlerCardSlot)selectedCardSlot;
                typedCardSlot.Health = Math.Min(typedCardSlot.Health + _amount, typedCardSlot.MaxHealth);
            }
            
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new Heal(_selection.Copy(), _amount);
        }
    }
}
