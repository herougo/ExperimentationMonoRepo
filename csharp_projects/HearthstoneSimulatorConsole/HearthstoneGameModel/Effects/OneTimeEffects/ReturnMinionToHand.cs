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
    public class ReturnMinionToHand : OneTimeEffect
    {
        SlotSelection _selection;

        public ReturnMinionToHand(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            game.CardMover.ReturnMinionsToHand(affectedCardSlot.Player, selectedCardSlots);

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new ReturnMinionToHand(_selection.Copy());
        }
    }
}
