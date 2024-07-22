using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.WrappedOneTimeEffects
{
    public class OneInXChanceEffect : WrappedOneTimeEffect
    {
        int _x;

        public OneInXChanceEffect(OneTimeEffect effect, int x)
            : base(effect)
        {
            _x = x;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            int randomNum = RandomGenerator.GetRandomInt(0, _x - 1);
            if (randomNum != 0)
            {
                return null;
            }
            return _effect.Execute(game, affectedCardSlot, originCardSlot, eventSlots);
        }

        public override OneTimeEffect Copy()
        {
            return new OneInXChanceEffect(_effect.Copy(), _x);
        }
    }
}
