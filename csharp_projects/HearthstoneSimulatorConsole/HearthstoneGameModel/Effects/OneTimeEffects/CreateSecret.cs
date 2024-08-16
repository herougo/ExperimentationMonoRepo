using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Triggers;
using HearthstoneGameModel.Game.SecretManagement;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class CreateSecret : OneTimeEffect
    {
        Trigger _trigger;
        OneTimeEffect _secretEffect;

        public CreateSecret(Trigger trigger, OneTimeEffect secretEffect)
        {
            _trigger = trigger;
            _secretEffect = secretEffect;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            Secret secret = new Secret((SpellCardSlot)affectedCardSlot, _trigger.Copy(), _secretEffect.Copy());
            AddSecretResult result = game.EffectManager.AddSecret(secret);
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new CreateSecret(_trigger.Copy(), _secretEffect.Copy());
        }
    }
}
