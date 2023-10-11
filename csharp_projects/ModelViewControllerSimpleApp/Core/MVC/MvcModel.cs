using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public class MvcModel : IEventParticipant<MvcModelInEvent, MvcModelOutEvent>
    {
        protected MvcController _controller;
        protected MvcModelInEventHandlerFactory _eventHandlerFactory;

        public void SendEvent(MvcModelOutEvent e)
        {
            _controller.ReceiveModelEvent(e);
        }

        public void ReceiveEvent(MvcModelInEvent e)
        {
            ModelInEventHandler handler = _eventHandlerFactory.GetEventHandler(e);
            handler.Handle(e);
        }
    }
}
