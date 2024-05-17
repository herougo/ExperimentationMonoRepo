using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
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
            HearthstoneGame game, CardSlot cardSlot
        );

        public abstract OneTimeEffect Copy();
    }
}
