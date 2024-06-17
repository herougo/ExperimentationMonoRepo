using HearthstoneGameModel.Game.CardSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game.EffectManagement
{
    public class EffectManagerNodePlan
    {
        public List<EffectManagerNode> ToAdd;
        public List<EffectManagerNode> ToRemove;
        public List<CardSlot> UpdateStats;
        public List<EffectEventArgs> EffectEventArgs;

        public EffectManagerNodePlan(
            List<EffectManagerNode> toAdd,
            List<EffectManagerNode> toRemove,
            List<CardSlot> updateStats,
            List<EffectEventArgs> effectEventArgs
        )
        {
            ToAdd = toAdd;
            ToRemove = toRemove;
            UpdateStats = updateStats;
            EffectEventArgs = effectEventArgs;
        }

        public EffectManagerNodePlan()
        {
            ToAdd = new List<EffectManagerNode>();
            ToRemove = new List<EffectManagerNode>();
            UpdateStats = new List<CardSlot>();
            EffectEventArgs = new List<EffectEventArgs>();
        }

        public void Perform(EffectManager effectManager)
        {
            foreach (EffectManagerNode node in ToAdd)
            {
                effectManager.AddEffect(node);
            }
            foreach (EffectManagerNode node in ToRemove)
            {
                effectManager.PopEffect(node);
            }
            foreach (CardSlot cardSlot in UpdateStats)
            {
                cardSlot.UpdateStats();
            }
            foreach (EffectEventArgs args in EffectEventArgs)
            {
                effectManager.SendEvent(args);
            }
        }

        public void Update(EffectManagerNodePlan newPlan)
        {
            if (newPlan == null)
            {
                return;
            }
            ToAdd.AddRange(newPlan.ToAdd);
            ToRemove.AddRange(newPlan.ToRemove);
            UpdateStats.AddRange(newPlan.UpdateStats);
            EffectEventArgs.AddRange(newPlan.EffectEventArgs);
        }

        public bool IsEmpty {
            get {
                return ToAdd.Count == 0 && ToRemove.Count == 0 && UpdateStats.Count == 0;    
            }
        }
    }
}
