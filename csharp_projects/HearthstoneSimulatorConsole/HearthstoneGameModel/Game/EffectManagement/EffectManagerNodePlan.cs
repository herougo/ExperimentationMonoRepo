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
        List<EffectManagerNode> ToAdd;
        List<EffectManagerNode> ToRemove;
        List<CardSlot> UpdateStats;

        public EffectManagerNodePlan(
            List<EffectManagerNode> toAdd,
            List<EffectManagerNode> toRemove,
            List<CardSlot> updateStats
        )
        {
            ToAdd = toAdd;
            ToRemove = toRemove;
            UpdateStats = updateStats;
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
        }

        public void Update(EffectManagerNodePlan newPlan)
        {
            ToAdd.AddRange(newPlan.ToAdd);
            ToRemove.AddRange(newPlan.ToRemove);
            UpdateStats.AddRange(newPlan.UpdateStats);
        }

        public bool IsEmpty {
            get {
                return ToAdd.Count == 0 && ToRemove.Count == 0 && UpdateStats.Count == 0;    
            }
        }
    }
}
