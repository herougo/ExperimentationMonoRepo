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
    public class GainArmour : OneTimeEffect
    {
        SlotSelection _selection;
        int _amount;

        public GainArmour(SlotSelection selection, int amount)
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
                HeroCardSlot typedSlot = (HeroCardSlot)selectedCardSlot;
                typedSlot.Armour += _amount;
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new GainArmour(_selection.Copy(), _amount);
        }
    }
}
