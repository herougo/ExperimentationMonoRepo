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
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class DealDamageToAdjacentMinions : OneTimeEffect
    {
        SlotSelection _selection;
        IIntValue _leftAmount;
        IIntValue _centreAmount;
        IIntValue _rightAmount;

        public DealDamageToAdjacentMinions(SlotSelection selection, int leftAmount, int centreAmount, int rightAmount)
        {
            _selection = selection;

            if (leftAmount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
            if (centreAmount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
            if (rightAmount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }

            _leftAmount = new ConstIntValue(leftAmount);
            _centreAmount = new ConstIntValue(centreAmount);
            _rightAmount = new ConstIntValue(rightAmount);

        }

        public DealDamageToAdjacentMinions(SlotSelection selection, IIntValue leftAmount, IIntValue centreAmount, IIntValue rightAmount)
        {
            _selection = selection;
            _leftAmount = leftAmount;
            _centreAmount = centreAmount;
            _rightAmount = rightAmount;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            if (selectedCardSlots.Count != 1)
            {
                throw new Exception("DealDamageToAdjacentMinions: must target 1 card");
            }
            CardSlot selectedCardSlot = selectedCardSlots[0];
            if (selectedCardSlot.CardType != CardType.Minion)
            {
                throw new Exception("DealDamageToAdjacentMinions: must target 1 minion");
            }
            MinionCardSlot cardSlot = (MinionCardSlot) selectedCardSlot;

            int boardIndex = game.Battleboard.CardSlotToBoardIndex(cardSlot);

            if (boardIndex == HearthstoneConstants.NullInt)
            {
                throw new Exception("DealDamageToAdjacentMinions: minion must be on the board");
            }

            Tuple<CardSlot, CardSlot> neighbours = game.Battleboard.GetNeighbours(cardSlot);

            attemptDealDamage(game, affectedCardSlot, cardSlot, _centreAmount);
            attemptDealDamage(game, affectedCardSlot, neighbours.Item1, _leftAmount);
            attemptDealDamage(game, affectedCardSlot, neighbours.Item2, _rightAmount);

            return null;
        }

        private void attemptDealDamage(HearthstoneGame game, CardSlot sourceCardSlot, CardSlot targetCardSlot, IIntValue amount)
        {
            if (targetCardSlot == null)
            {
                return;
            }
            if (targetCardSlot.CardType != CardType.Minion)
            {
                return;
            }
            int calculcatedAmount = amount.Get(game, sourceCardSlot);
            game.DealDamage(sourceCardSlot, new List<BattlerCardSlot> { (MinionCardSlot)targetCardSlot }, calculcatedAmount);
        }

        public override OneTimeEffect Copy()
        {
            return new DealDamageToAdjacentMinions(_selection.Copy(), _leftAmount, _centreAmount, _rightAmount);
        }
    }
}
