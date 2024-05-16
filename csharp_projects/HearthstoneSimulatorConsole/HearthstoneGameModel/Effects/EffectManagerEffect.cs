using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Effects
{
    public abstract class EffectManagerEffect
    {
        protected List<string> _eventsReceived;
        protected bool _requiresSlotMatchForEvent = false;
        protected bool _requiresSlotPlayerMatchForEvent = false;

        public abstract EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode);

        public virtual EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public EffectManagerNodePlan SendEvent(
            string effectEvent, HearthstoneGame game,
            EffectManagerNode emNode, CardSlot eventSlot)
        {
            return null;
        }

        public ReadOnlyCollection<string> EventsReceived {
            get { return _eventsReceived.AsReadOnly(); }
        }

        public bool RequiresSlotMatchForEvent { 
            get { return _requiresSlotMatchForEvent; }
        }

        public bool RequiresSlotPlayerMatchForEvent
        {
            get { return _requiresSlotPlayerMatchForEvent; }
        }

        public void AdjustStats()
        {

        }

        public abstract EffectManagerEffect Copy();
    }
}
