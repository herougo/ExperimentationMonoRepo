using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    interface IEventHandlerFactory<TEventHandler>
    {
        TEventHandler GetEventHandler(IEvent e);
    }

    public abstract class MvcModelInEventHandlerFactory : IEventHandlerFactory<ModelInEventHandler>
    {
        protected MvcModel _eventParticipant;

        public MvcModelInEventHandlerFactory(MvcModel eventParicipant) {
            _eventParticipant = eventParicipant;
        }

        public abstract ModelInEventHandler GetEventHandler(IEvent e);
    }

    public abstract class MvcModelOutEventHandlerFactory : IEventHandlerFactory<ModelOutEventHandler>
    {
        protected MvcView _eventParticipant;

        public MvcModelOutEventHandlerFactory(MvcView eventParicipant)
        {
            _eventParticipant = eventParicipant;
        }

        public abstract ModelOutEventHandler GetEventHandler(IEvent e);
    }

    public abstract class MvcViewOutEventHandlerFactory : IEventHandlerFactory<ViewOutEventHandler>
    {
        protected MvcController _eventParticipant;

        public MvcViewOutEventHandlerFactory(MvcController eventParicipant)
        {
            _eventParticipant = eventParicipant;
        }

        public abstract ViewOutEventHandler GetEventHandler(IEvent e);
    }
}
