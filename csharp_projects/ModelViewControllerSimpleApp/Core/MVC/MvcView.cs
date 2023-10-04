using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class MvcView : IEventParticipant<ModelOutEvent, ViewOutEvent>
    {
        protected MvcController _controller;
        protected MvcModel _model;
        public void SendEvent(ViewOutEvent e)
        {
            _controller.ReceiveViewEvent(e);
        }

        public abstract void ReceiveEvent(ModelOutEvent e);
    }
}
