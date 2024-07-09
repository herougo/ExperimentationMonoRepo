using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EffectManagerNode
    {
        public EMEffect Effect;
        public CardSlot AffectedSlot;
        public CardSlot OriginSlot;
        public bool Silenceable;
        int _hash;

        public EffectManagerNode(
            EMEffect effect,
            CardSlot affectedSlot,
            CardSlot originSlot,
            bool silenceable) // TODO: add hash parameter?
        {
            Effect = effect.Copy();
            AffectedSlot = affectedSlot;
            OriginSlot = originSlot;
            Silenceable = silenceable;
            _hash = HashGenerator.GetNextHash();
        }

        public EffectManagerNodePlan Start(HearthstoneGame game, EffectManager effectManager)
        {
            EffectManagerNodePlan plan = Effect.Start(game, this);
            return plan;
        }

        public EffectManagerNodePlan Stop(HearthstoneGame game, EffectManager effectManager)
        {
            EffectManagerNodePlan plan = Effect.Stop(game, this);
            return plan;
        }

        public void SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManager effectManager, List<CardSlot> eventSlots)
        {
            EffectManagerNodePlan plan = Effect.SendEvent(effectEvent, game, this, eventSlots);
            if (plan != null)
            {
                plan.Perform(effectManager);
            }
        }

        public int Hash {  get { return _hash; } }

        public override int GetHashCode()
        {
            return Hash;
        }

        public override bool Equals(object o)
        {
            return (o as EffectManagerNode)?.Hash == Hash;
        }

        public int Priority { get { return Effect.Priority; } }
    }
}
