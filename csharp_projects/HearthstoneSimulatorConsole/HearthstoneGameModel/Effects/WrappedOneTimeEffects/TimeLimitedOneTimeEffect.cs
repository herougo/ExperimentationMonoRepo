using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Effects.WrappedEMEffects;

namespace HearthstoneGameModel.Effects.WrappedOneTimeEffects
{
    public class TimeLimitedOneTimeEffect : WrappedOneTimeEffect
    {
        EffectTimeLimit _untilWhen;

        public TimeLimitedOneTimeEffect(OneTimeEffect effect, EffectTimeLimit untilWhen)
            : base(effect)
        {
            _untilWhen = untilWhen;
        }

        private bool isTimeUp(int endingTurn, int affectedSlotPlayer)
        {
            if (_untilWhen == EffectTimeLimit.NoLimit)
            {
                return false;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfTurn)
            {
                return true;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfPlayerTurn)
            {
                return endingTurn == affectedSlotPlayer;
            }
            else if (_untilWhen == EffectTimeLimit.EndOfOpponentTurn)
            {
                return endingTurn != affectedSlotPlayer;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot
        )
        {
            EffectManagerNodePlan plan = _effect.Execute(game, affectedCardSlot, originCardSlot);
            if (plan != null)
            {
                foreach (EffectManagerNode toAddNode in plan.ToAdd)
                {
                    toAddNode.Effect = new TimeLimitedEMEffect(toAddNode.Effect, _untilWhen);
                }
            }
            return plan;
        }

        public override OneTimeEffect Copy()
        {
            return new TimeLimitedOneTimeEffect(_effect.Copy(), _untilWhen);
        }
    }
}
