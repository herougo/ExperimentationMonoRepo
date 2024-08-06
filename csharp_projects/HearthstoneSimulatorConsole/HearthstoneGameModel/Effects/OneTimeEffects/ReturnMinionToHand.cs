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

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            List<CardSlot> selectedCardSlotsPlayer0 = selectedCardSlots.Where(x => x.Player == 0).ToList();
            List<CardSlot> selectedCardSlotsPlayer1 = selectedCardSlots.Where(x => x.Player == 1).ToList();
            
            game.CardMover.ReturnMinionsToHand(0, selectedCardSlotsPlayer0);
            game.CardMover.ReturnMinionsToHand(1, selectedCardSlotsPlayer1);

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new ReturnMinionToHand(_selection.Copy());
        }
    }
}
