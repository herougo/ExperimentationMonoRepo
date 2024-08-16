using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.SecretManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class ExtendedEffectManager : EffectManager
    {
        public PlayerSecretManager[] PlayerSecretManagers;

        public ExtendedEffectManager(HearthstoneGame game)
            : base(game)
        {
            PlayerSecretManagers = new PlayerSecretManager[2]
            {
                new PlayerSecretManager(game),
                new PlayerSecretManager(game)
            };
        }

        public override void SendEvent(string effectEvent, List<CardSlot> eventSlots)
        {
            List<EffectManagerNode> relevantEMNodes = _eventToEffectNodeList.GetRelevantEMNodes(effectEvent, eventSlots[0]);
            foreach (EffectManagerNode emNode in relevantEMNodes)
            {
                emNode.SendEvent(effectEvent, _game, eventSlots);
            }
            _game.KillIfNecessary();

            PlayerSecretManagers[1 - _game.GameMetadata.Turn].SendEvent(effectEvent, eventSlots);
            _game.KillIfNecessary();
        }
    }
}
