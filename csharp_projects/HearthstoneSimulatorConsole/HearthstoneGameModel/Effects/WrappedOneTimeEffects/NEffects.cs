using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedOneTimeEffects
{
    public class NEffects : WrappedOneTimeEffect
    {
        int _numExecutes;

        public NEffects(OneTimeEffect effect, int numExecutes) : base(effect)
        {
            _numExecutes = numExecutes;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            for (int i = 0; i < _numExecutes; i++)
            {
                plan.Update(_effect.Execute(game, affectedCardSlot, originCardSlot));
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new NEffects(_effect.Copy(), _numExecutes);
        }
    }
}
