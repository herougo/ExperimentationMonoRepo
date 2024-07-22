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

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<BattlerCardSlot> typedSelectedCardSlots = selectedCardSlots.Select(x => (BattlerCardSlot)x).ToList();

            game.DealDamage(affectedCardSlot, typedSelectedCardSlots, _amount);

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new DealDamage(_selection.Copy(), _amount);
        }
    }
}
