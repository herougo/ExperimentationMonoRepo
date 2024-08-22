using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class ResetTurnPlayerMetadata : OneTimeEffect
    {
        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = affectedCardSlot.Player;
            game.PlayerMetadata[player].MinionPlayCount = 0;
            EffectManagerNodePlan plan = new EffectManagerNodePlan();
            plan.UpdateStats.Add(game.Players[0]);
            plan.UpdateStats.Add(game.Players[1]);
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new ResetTurnPlayerMetadata();
        }
    }
}
