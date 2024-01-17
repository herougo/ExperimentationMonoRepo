using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormView;

namespace WebFormController.Events
{
    internal class WebFormControllerEventReceiver : IEventReceiver
    {
        ViewOutEventHandlerFactory _viewOutEventHandlerFactory;

        public WebFormControllerEventReceiver(MvcWebFormController controller)
        {
            _viewOutEventHandlerFactory = new ViewOutEventHandlerFactory(controller);
        }

        public void Receive(IEvent e)
        {
            ViewOutEventHandler handler = _viewOutEventHandlerFactory.GetEventHandler(e);
            handler.Handle((MvcViewOutEvent)e);
        }
        
    }
}
