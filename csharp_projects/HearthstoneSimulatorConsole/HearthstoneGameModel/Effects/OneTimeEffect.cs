using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class OneTimeEffect
    {
        public abstract EffectManagerNodePlan Execute(
            HearthstoneGame game, EffectManager effectManager
        );

        public abstract OneTimeEffect Copy();
    }
}
