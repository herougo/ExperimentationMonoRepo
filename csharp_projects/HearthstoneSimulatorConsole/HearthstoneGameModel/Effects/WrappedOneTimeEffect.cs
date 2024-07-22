using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public class WrappedOneTimeEffect : OneTimeEffect
    {
        protected OneTimeEffect _effect;

        public WrappedOneTimeEffect(OneTimeEffect effect)
        {
            _effect = effect;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            return _effect.Execute(game, affectedCardSlot, originCardSlot, eventSlots);
        }

        public override OneTimeEffect Copy()
        {
            return new WrappedOneTimeEffect(_effect.Copy());
        }
    }
}
