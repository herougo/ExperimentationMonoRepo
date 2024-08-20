using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Values;

namespace HearthstoneGameModel.Effects.WrappedOneTimeEffects
{
    public class NEffects : WrappedOneTimeEffect
    {
        IIntValue _numExecutes;

        public NEffects(OneTimeEffect effect, int numExecutes) : base(effect)
        {
            _numExecutes = new ConstIntValue(numExecutes);
        }

        public NEffects(OneTimeEffect effect, IIntValue numExecutes) : base(effect)
        {
            _numExecutes = numExecutes;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int numExecutes = _numExecutes.Get(game, affectedCardSlot);
            for (int i = 0; i < numExecutes; i++)
            {
                EffectManagerNodePlan plan = _effect.Execute(game, affectedCardSlot, originCardSlot, eventSlots);
                if (plan != null)
                {
                    plan.Perform(game);
                }
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new NEffects(_effect.Copy(), _numExecutes);
        }
    }
}
