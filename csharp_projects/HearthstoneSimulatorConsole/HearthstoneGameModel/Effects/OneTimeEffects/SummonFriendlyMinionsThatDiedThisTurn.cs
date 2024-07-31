using HearthstoneGameModel.Cards.CardTypes;
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

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SummonFriendlyMinionsThatDiedThisTurn : OneTimeEffect
    {
        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = affectedCardSlot.Player;
            Tuple<int, int> graveyardIndicesRange = game.GraveyardTracker.GetTurnIndicesRange(game.GameMetadata.TurnCount);
            int graveyardStart = graveyardIndicesRange.Item1;
            int graveyardEnd = graveyardIndicesRange.Item2;

            for ( int graveyardIndex = graveyardStart; graveyardIndex <= graveyardEnd; graveyardIndex++ )
            {
                if (!game.Battleboard.HasRoom(player))
                {
                    break;
                }
                GraveyardTrackerEntry entry = game.GraveyardTracker[graveyardIndex];
                if (player != entry.Player)
                {
                    continue;
                }
                MinionCardSlot newMinionCardSlot = (MinionCardSlot)entry.Card.CreateCardSlot(player, game);
                game.CardMover.SummonMinion(newMinionCardSlot);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new SummonFriendlyMinionsThatDiedThisTurn();
        }
    }
}
