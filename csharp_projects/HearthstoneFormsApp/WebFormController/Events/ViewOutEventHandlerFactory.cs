using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFormView.Events.Enums;
using WebFormView.Events;

namespace WebFormController.Events
{
    internal class ViewOutEventHandlerFactory : MvcViewOutEventHandlerFactory
    {
        protected MvcWebFormController _controller;

        public ViewOutEventHandlerFactory(MvcWebFormController controller)
        {
            _controller = controller;
        }

        public override ViewOutEventHandler GetEventHandler(IEvent e)
        {
            ViewOutEvent eTyped = (ViewOutEvent)e;
            ViewOutEvents eventEnum = eTyped.GetEnum();
            ViewOutEventHandler handler = null;
            switch (eventEnum)
            {
                
            }
            return handler;
        }
    }
}
