using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Core.Enums;

namespace HearthstoneGameModel.Effects
{
    public abstract class EMEffect
    {
        protected List<string> _eventsReceived = new List<string>();
        protected bool _requiresSlotMatchForEvent = false;
        protected bool _requiresSlotPlayerMatchForEvent = false;
        protected EffectArea _effectArea = EffectArea.Field;

        public virtual EffectManagerNodePlan Start(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public virtual EffectManagerNodePlan Stop(HearthstoneGame game, EffectManagerNode emNode)
        {
            return null;
        }

        public virtual EffectManagerNodePlan SendEvent(
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

        public EffectArea EffectArea
        {
            get { return _effectArea; }
        }

        public virtual void AdjustStats(BattlerCardSlot cardSlot)
        {

        }

        protected void CheckValidEvent(string effectEvent)
        {
            if (!EventsReceived.Contains(effectEvent))
            {
                throw new Exception("effectEvent not in EventsReceived");
            }
        }

        public abstract EMEffect Copy();
    }
}
