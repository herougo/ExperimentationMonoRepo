using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Selections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.Metadata;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class RefreshAllManaCrystals : OneTimeEffect
    {
        SlotSelection _selection;

        public RefreshAllManaCrystals(SlotSelection selection)
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
                int player = slot.Player;
                PlayerMetadata playerMetadata = game.PlayerMetadata[player];
                playerMetadata.CurrentMana = playerMetadata.AvailableMana;
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new RefreshAllManaCrystals(_selection.Copy());
        }
    }
}
