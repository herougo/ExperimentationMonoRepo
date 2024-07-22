using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class BecomeMinionCopy : OneTimeEffect
    {
        SlotSelection _selection;

        public BecomeMinionCopy(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            if (selectedCardSlots.Count == 0)
            {
                return null;
            }
            if (selectedCardSlots.Count > 1)
            {
                throw new Exception("BecomeMinionCopy must have exactly 0 or 1 selection");
            }

            return ((MinionCardSlot)affectedCardSlot).InPlayCopyFrom((MinionCardSlot)selectedCardSlots[0]);
        }

        public override OneTimeEffect Copy()
        {
            return new BecomeMinionCopy(_selection.Copy());
        }
    }
}
