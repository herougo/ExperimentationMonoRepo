using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class MvcController
    {
        protected MvcModel _model;
        protected MvcView _view;
        protected MvcViewOutEventHandlerFactory _eventHandlerFactory;

        public void ReceiveModelEvent(ModelOutEvent e)
        {
            _view.ReceiveEvent(e);
        }
        public void ReceiveViewEvent(ViewOutEvent e)
        {
            ViewOutEventHandler handler = _eventHandlerFactory.GetEventHandler(e);
            handler.Handle(e);
        }
    }
}
