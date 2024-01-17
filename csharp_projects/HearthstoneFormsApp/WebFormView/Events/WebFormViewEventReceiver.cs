using GameModel.Events;
using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormView.Events;
using WebFormView;

namespace GameModel.Events
{
    public class WebFormViewEventReceiver : IEventReceiver
    {
        ModelOutEventHandlerFactory _modelOutEventHandlerFactory;

        public WebFormViewEventReceiver(MvcWebFormView view)
        {
            _modelOutEventHandlerFactory = new ModelOutEventHandlerFactory(view);
        }

        public void Receive(IEvent e)
        {
            ModelOutEventHandler handler = _modelOutEventHandlerFactory.GetEventHandler(e);
            handler.Handle((MvcModelOutEvent)e);
        }
    }
}
