using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class DestroyAllSecrets : OneTimeEffect
    {
        PlayerChoice _playerChoice;

        public DestroyAllSecrets(PlayerChoice playerChoice)
        {
            _playerChoice = playerChoice;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            if (_playerChoice == PlayerChoice.Both)
            {
                game.EffectManager.PlayerSecretManagers[0].DestroyAllSecrets();
                game.EffectManager.PlayerSecretManagers[1].DestroyAllSecrets();
            }
            int relevantPlayer = HSGameUtils.ComputePlayer(affectedCardSlot.Player, _playerChoice);
            game.EffectManager.PlayerSecretManagers[relevantPlayer].DestroyAllSecrets();
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new DestroyAllSecrets(_playerChoice);
        }
    }
}
