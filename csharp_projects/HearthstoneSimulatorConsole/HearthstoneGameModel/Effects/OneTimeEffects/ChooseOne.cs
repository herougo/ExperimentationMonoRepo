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
    public class ChooseOne : OneTimeEffect
    {
        List<OneTimeEffect> _effects;

        public ChooseOne(OneTimeEffect effect0, OneTimeEffect effect1)
        {
            _effects = new List<OneTimeEffect> { effect0, effect1 };
        }

        public ChooseOne(List<OneTimeEffect> effects)
        {
            _effects = effects;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int choice = game.GetChoiceFromAction(_effects.Count, affectedCardSlot.Player);

            return _effects[choice].Execute(game, affectedCardSlot, originCardSlot, eventSlots);
        }

        public override OneTimeEffect Copy()
        {
            return new ChooseOne(_effects.Select(x => x.Copy()).ToList());
        }
    }
}
