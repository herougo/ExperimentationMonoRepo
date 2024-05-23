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
    public class RefreshAllManaCrystals : OneTimeEffect
    {
        CharacterSelection _selection;

        public RefreshAllManaCrystals(CharacterSelection selection)
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
                typedSlot.CurrentMana = typedSlot.AvailableMana;
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new RefreshAllManaCrystals(_selection.Copy());
        }
    }
}
