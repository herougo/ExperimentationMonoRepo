using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class AddEventSlotCopyToHand : OneTimeEffect
    {
        PlayerChoice _toPlayer;

        public AddEventSlotCopyToHand(PlayerChoice toPlayer) {
            _toPlayer = toPlayer;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            CardSlot spellCardSlot = eventSlots[0];
            int player = spellCardSlot.Player;
            int receivingPlayer = HSGameUtils.ComputePlayer(player, _toPlayer);
            game.CreateCardAndAddToHand(receivingPlayer, spellCardSlot.Card);
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new AddEventSlotCopyToHand(_toPlayer);
        }
    }
}
