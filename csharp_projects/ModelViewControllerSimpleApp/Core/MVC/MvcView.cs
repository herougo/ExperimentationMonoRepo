using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class MvcView : IEventParticipant<MvcModelOutEvent, MvcViewOutEvent>
    {
        protected MvcController _controller;
        protected MvcModelOutEventHandlerFactory _eventHandlerFactory;

        public void SendEvent(MvcViewOutEvent e)
        {
            _controller.ReceiveViewEvent(e);
        }

        public void ReceiveEvent(MvcModelOutEvent e)
        {
            ModelOutEventHandler handler = _eventHandlerFactory.GetEventHandler(e);
            handler.Handle(e);
        }
    }
}
