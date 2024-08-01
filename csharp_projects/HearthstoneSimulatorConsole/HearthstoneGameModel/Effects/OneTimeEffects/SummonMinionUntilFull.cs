using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using System.Collections.Generic;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SummonMinionUntilFull : OneTimeEffect
    {
        MinionCard _minion;
        PlayerChoice _playerChoice;

        public SummonMinionUntilFull(MinionCard minion) {
            _minion = minion;
            _playerChoice = PlayerChoice.Player;
        }

        public SummonMinionUntilFull(MinionCard minion, PlayerChoice playerChoice)
        {
            _minion = minion;
            _playerChoice = playerChoice;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = HSGameUtils.ComputePlayer(affectedCardSlot.Player, _playerChoice);
            while (game.Battleboard.HasRoom(player))
            {
                MinionCardSlot newMinionCardSlot = (MinionCardSlot)_minion.CreateCardSlot(player, game);
                game.CardMover.SummonMinion(newMinionCardSlot);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new SummonMinionUntilFull((MinionCard)_minion.Copy(), _playerChoice);
        }
    }
}
