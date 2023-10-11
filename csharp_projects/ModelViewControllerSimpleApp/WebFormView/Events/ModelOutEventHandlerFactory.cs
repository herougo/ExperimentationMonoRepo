using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationModel.Events;
using ApplicationModel.Events.Enums;
using WebFormView.Events.ModelOutEventHandlers;

namespace WebFormView.Events
{
    internal class ModelOutEventHandlerFactory : MvcModelOutEventHandlerFactory
    {
        protected MainWebFormView _view;

        public ModelOutEventHandlerFactory(MainWebFormView view)
        {
            _view = view;
        }

        public override ModelOutEventHandler GetEventHandler(IEvent e)
        {
            ModelOutEvent eTyped = (ModelOutEvent)e;
            ModelOutEvents eventEnum = eTyped.GetEnum();
            ModelOutEventHandler handler = null;
            switch (eventEnum)
            {
                case ModelOutEvents.PictureBoxSelectorUpdated:
                    handler = new PictureBoxSelectorUpdatedEventHandler(_view);
                    break;
            }
            return handler;
        }
    }
}
