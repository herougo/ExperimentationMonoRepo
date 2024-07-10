using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects.ContinuousEffects
{
    public class SpellDamage : ContinuousEffect
    {
        int _amount;

        public SpellDamage(int amount)
        {
            _amount = amount;
        }

        public override EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            game.PlayerMetadata[player].SpellDamage += _amount;
            return null;
        }

        public override EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            int player = emNode.AffectedSlot.Player;
            game.PlayerMetadata[player].SpellDamage -= _amount;
            if (game.PlayerMetadata[player].SpellDamage < 0)
            {
                throw new Exception("negative SpellDamage");
            }
            return null;
        }

        public override EMEffect Copy()
        {
            return new SpellDamage(_amount);
        }
    }
}
