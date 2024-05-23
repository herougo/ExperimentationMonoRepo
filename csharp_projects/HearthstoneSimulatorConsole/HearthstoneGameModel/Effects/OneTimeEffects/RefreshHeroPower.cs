using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class RefreshHeroPower : OneTimeEffect
    {
        CharacterSelection _selection;

        public RefreshHeroPower(CharacterSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot);
            foreach (CardSlot slot in selectedCardSlots)
            {
                HeroCardSlot typedSlot = (HeroCardSlot)slot;
                typedSlot.HeroPowerUsedThisTurn = false;
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new RefreshAttacks(_selection.Copy());
        }
    }
}
