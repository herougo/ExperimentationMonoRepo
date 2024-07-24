using HearthstoneGameModel.CardGeneration;
using HearthstoneGameModel.Cards;
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
    public class TransformInPlayMinion : OneTimeEffect
    {
        SlotSelection _selection;
        ICardGenerator _cardGenerator;

        public TransformInPlayMinion(SlotSelection selection, ICardGenerator cardGenerator)
        {
            _selection = selection;
            _cardGenerator = cardGenerator;
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
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            foreach (CardSlot slot in selectedCardSlots)
            {
                Card card = _cardGenerator.Generate(game, affectedCardSlot, originCardSlot, eventSlots);
                MinionCardSlot typedCardSlot = (MinionCardSlot)slot;
                plan.Update(game.InPlayTransform(typedCardSlot, card));
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new TransformInPlayMinion(_selection.Copy(), _cardGenerator.Copy());
        }
    }
}
