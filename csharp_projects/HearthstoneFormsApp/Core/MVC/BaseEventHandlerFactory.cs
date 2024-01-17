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
        public abstract ModelInEventHandler GetEventHandler(IEvent e);
    }

    public abstract class MvcModelOutEventHandlerFactory : IEventHandlerFactory<ModelOutEventHandler>
    {
        public abstract ModelOutEventHandler GetEventHandler(IEvent e);
    }

    public abstract class MvcViewOutEventHandlerFactory : IEventHandlerFactory<ViewOutEventHandler>
    {
        public abstract ViewOutEventHandler GetEventHandler(IEvent e);
    }
}
