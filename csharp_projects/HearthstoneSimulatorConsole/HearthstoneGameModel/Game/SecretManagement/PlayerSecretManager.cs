using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.UI.UIEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.SecretManagement
{
    public class PlayerSecretManager
    {
        List<Secret> _secrets = new List<Secret>();
        HearthstoneGame _game;

        public PlayerSecretManager(HearthstoneGame game)
        {
            _game = game;
        }

        public AddSecretResult AddSecret(Secret secret)
        {
            if (_secrets.Count == HearthstoneConstants.MaxNumOfSecrets)
            {
                return AddSecretResult.Full;
            }

            /*
            string secretCardId = secret.CardSlot.Card.CardId;
            foreach (Secret existingSecret in _secrets)
            {
                if (secretCardId == existingSecret.CardSlot.Card.CardId)
                {
                    return AddSecretResult.DuplicateSecret;
                }
            }
            */

            _secrets.Add(secret);

            return AddSecretResult.Success;
        }

        public void SendEvent(
            string effectEvent, List<CardSlot> eventSlots
        )
        {
            int i = -1;
            while (i + 1 < _secrets.Count)
            {
                i += 1;
                Secret secret = _secrets[i];

                if (!secret.Trigger.EventsReceived.Contains(effectEvent))
                {
                    continue;
                }

                int player = eventSlots[0].Player;
                if (secret.Trigger.RequiresSlotPlayerMatchForEvent && player != secret.CardSlot.Player)
                {
                    continue;
                }

                if (secret.Trigger.RequiresSlotMatchForEvent && eventSlots[0] != secret.CardSlot)
                {
                    continue;
                }

                if (!secret.Trigger.ShouldRun(effectEvent, _game, secret.CardSlot, eventSlots))
                {
                    continue;
                }

                _game.UIManager.ReceiveUIEvent(new SecretRevealedUIEvent(secret.CardSlot.Card.Name));
                _game.EffectManager.Execute(secret.OneTimeEffect, secret.CardSlot, eventSlots);

                _secrets.RemoveAt(i);
                i -= 1;
            }
        }

        public int NumSecrets
        {
            get {  return _secrets.Count; }
        }
    }
}
