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
    public class RefreshHeroPower : OneTimeEffect
    {
        SlotSelection _selection;

        public RefreshHeroPower(SlotSelection selection)
        {
            _selection = selection;
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            List<CardSlot> selectedCardSlots = _selection.GetSelectedCardSlots(game, affectedCardSlot, originCardSlot, eventSlots);
            foreach (CardSlot slot in selectedCardSlots)
            {
                int player = game.GameMetadata.Turn;
                PlayerMetadata playerMetadata = game.PlayerMetadata[player];
                playerMetadata.HeroPowerUsedThisTurn = false;
            }

            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new RefreshHeroPower(_selection.Copy());
        }
    }
}
