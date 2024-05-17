using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SummonMinion : OneTimeEffect
    {
        MinionCard _minion;

        public SummonMinion(MinionCard minion) { _minion = minion; }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            if (game.Battleboard.HasRoom(player))
            {
                CardSlot cardSlot = _minion.CreateCardSlot(player, game);
                game.CardMover.SummonMinion(cardSlot);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new SummonMinion((MinionCard)_minion.Copy());
        }
    }
}
