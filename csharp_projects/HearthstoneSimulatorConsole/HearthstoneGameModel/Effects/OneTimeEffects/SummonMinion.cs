﻿using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SummonMinion : OneTimeEffect
    {
        MinionCard _minion;

        public SummonMinion(MinionCard minion) { _minion = minion; }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            int player = affectedCardSlot.Player;
            if (game.Battleboard.HasRoom(player))
            {
                CardSlot newMinionCardSlot = _minion.CreateCardSlot(player, game);
                game.CardMover.SummonMinion(newMinionCardSlot);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new SummonMinion((MinionCard)_minion.Copy());
        }
    }
}