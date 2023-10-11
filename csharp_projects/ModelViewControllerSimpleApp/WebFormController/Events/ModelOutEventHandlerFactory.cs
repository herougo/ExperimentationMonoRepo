using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFormView.Events.Enums;
using WebFormView.Events;
using WebFormController.Events.ViewOutEventHandlers;

namespace WebFormController.Events
{
    internal class ViewOutEventHandlerFactory : MvcViewOutEventHandlerFactory
    {
        protected MainWebFormController _controller;

        public ViewOutEventHandlerFactory(MainWebFormController controller)
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
                case ViewOutEvents.PictureBoxClicked:
                    handler = new PictureBoxClickedEventHandler(_controller);
                    break;
            }
            return handler;
        }
    }
}
