using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Triggers;

namespace HearthstoneGameModel.Effects.ActivatedEffects
{
    public class HeroPowerEffect : ActivatedEffect
    {
        public HeroPowerEffect(OneTimeEffect effect)
            : base(new HeroPowerActivation(), effect) { }

        public override EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, List<CardSlot> eventSlots)
        {
            CheckValidEvent(effectEvent);
            if (!_trigger.ShouldRun(effectEvent, game, emNode.AffectedSlot, eventSlots))
            {
                return null;
            }
            EffectManagerNodePlan result = _effect.Execute(game, emNode.AffectedSlot, emNode.OriginSlot, eventSlots);
            game.PlayerMetadata[emNode.AffectedSlot.Player].HeroPowerUsedThisTurn = true;
            return result;
        }

        public override EMEffect Copy()
        {
            return new HeroPowerEffect(_effect.Copy());
        }
    }
}
