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
    public class GainManaCrystals : OneTimeEffect
    {
        SlotSelection _selection;
        int _amount;

        public GainManaCrystals(SlotSelection selection, int amount)
        {
            _selection = selection;
            _amount = amount;
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be positive");
            }
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
                playerMetadata.AvailableMana = Math.Min(playerMetadata.MaximumMana, playerMetadata.AvailableMana + _amount);
                playerMetadata.CurrentMana = Math.Min(playerMetadata.MaximumMana, playerMetadata.CurrentMana + _amount);
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new GainManaCrystals(_selection.Copy(), _amount);
        }
    }
}
