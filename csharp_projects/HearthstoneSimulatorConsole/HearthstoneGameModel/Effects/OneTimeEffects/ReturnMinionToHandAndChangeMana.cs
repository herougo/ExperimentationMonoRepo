using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.HandContinuousEffects;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class ReturnMinionToHandAndChangeMana : OneTimeEffect
    {
        SlotSelection _selection;
        int _manaChange;

        public ReturnMinionToHandAndChangeMana(SlotSelection selection, int manaChange)
        {
            _selection = selection;
            _manaChange = manaChange;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            List<CardSlot> selectedCardSlotsPlayer0 = selectedCardSlots.Where(x => x.Player == 0).ToList();
            List<CardSlot> selectedCardSlotsPlayer1 = selectedCardSlots.Where(x => x.Player == 1).ToList();
            
            game.CardMover.ReturnMinionsToHand(0, selectedCardSlotsPlayer0);
            game.CardMover.ReturnMinionsToHand(1, selectedCardSlotsPlayer1);

            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            int amount = Math.Abs(_manaChange);
            int multiplier = 1;
            if (_manaChange < 0)
            {
                multiplier = -1;
            }
            foreach (CardSlot slot in selectedCardSlots)
            {
                EffectManagerNode node = new EffectManagerNode(
                    new ManaChange(amount, multiplier), slot, slot, false
                );
                plan.ToAdd.Add(node);
            }

            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new ReturnMinionToHandAndChangeMana(_selection.Copy(), _manaChange);
        }
    }
}
