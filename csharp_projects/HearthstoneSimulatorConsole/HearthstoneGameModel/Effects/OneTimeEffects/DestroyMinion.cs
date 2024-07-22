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
    public class DestroyMinion : OneTimeEffect
    {
        SlotSelection _selection;

        public DestroyMinion(SlotSelection selection) {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> slots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            foreach (CardSlot slot in slots)
            {
                ((MinionCardSlot)slot).IsDestroyed = true;
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new DestroyMinion(_selection.Copy());
        }
    }
}
