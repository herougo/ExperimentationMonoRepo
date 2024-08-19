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
    public class RefreshAttacks : OneTimeEffect
    {
        SlotSelection _selection;

        public RefreshAttacks(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            foreach (CardSlot slot in selectedCardSlots)
            {
                BattlerCardSlot typedSlot = (BattlerCardSlot)slot;
                typedSlot.AttacksThisTurn = 0;
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new RefreshAttacks(_selection.Copy());
        }

    }
}
