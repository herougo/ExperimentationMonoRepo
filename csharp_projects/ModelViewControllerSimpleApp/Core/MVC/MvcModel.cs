using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    class MvcModel : IEventParticipant<ModelInEvent, ModelOutEvent>
    {
        protected MvcController controller;

        public void SendEvent(ModelOutEvent e)
        {
            controller.ReceiveModelEvent(e);
        }

        public void ReceiveEvent(ModelInEvent e)
        {
            ModelInEventHandler handler = e.GetHandler();
            handler.Handle(e, this);
        }
    }
}
