using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    abstract class MvcView : IEventParticipant<ModelOutEvent, ViewOutEvent>
    {
        protected MvcController controller;
        protected MvcModel model;
        public void SendEvent(ViewOutEvent e)
        {
            controller.ReceiveViewEvent(e);
        }

        public abstract void ReceiveEvent(ModelOutEvent e);
    }
}
