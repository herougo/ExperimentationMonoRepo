﻿using HearthstoneGameModel.Effects;
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
        public ContinuousEffect Effect;
        public CardSlot AffectedSlot;
        public CardSlot OriginSlot;
        public bool Silencable;
        int _hash;

        public EffectManagerNode(
            ContinuousEffect effect,
            CardSlot affectedSlot,
            CardSlot originSlot,
            bool silenceable) // TODO: add hash parameter?
        {
            Effect = effect.Copy();
            AffectedSlot = affectedSlot;
            OriginSlot = originSlot;
            Silencable = silenceable;
            _hash = HashGenerator.GetNextHash();
        }

        public void Start(HearthstoneGame game, EffectManager effectManager)
        {
            EffectManagerNodePlan plan = Effect.Start(game, this);
            if (plan != null)
            {
                plan.Perform(effectManager);
            }
        }

        public void Stop(HearthstoneGame game, EffectManager effectManager)
        {
            EffectManagerNodePlan plan = Effect.Stop(game, this);
            if (plan != null)
            {
                plan.Perform(effectManager);
            }
        }

        public void SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManager effectManager, CardSlot eventSlot)
        {
            EffectManagerNodePlan plan = Effect.SendEvent(effectEvent, game, this, eventSlot);
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

    }
}