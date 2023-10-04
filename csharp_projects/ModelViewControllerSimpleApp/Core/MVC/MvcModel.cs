using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public class MvcModel : IEventParticipant<ModelInEvent, ModelOutEvent>
    {
        protected MvcController _controller;

        public void SendEvent(ModelOutEvent e)
        {
            _controller.ReceiveModelEvent(e);
        }

        public void ReceiveEvent(ModelInEvent e)
        {
            ModelInEventHandler handler = e.GetHandler();
            handler.Handle(e, this);
        }
    }
}
