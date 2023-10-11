using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationModel.Events.Enums;
using ApplicationModel.Events.ModelInEventHandlers;

namespace ApplicationModel.Events
{
    internal class ModelInEventHandlerFactory : MvcModelInEventHandlerFactory
    {
        protected MainModel _model;

        public ModelInEventHandlerFactory(MainModel model)
        {
            _model = model;
        }

        public override ModelInEventHandler GetEventHandler(IEvent e)
        {
            ModelInEvent eTyped = (ModelInEvent)e;
            ModelInEvents eventEnum = eTyped.GetEnum();
            ModelInEventHandler handler = null;
            switch (eventEnum)
            {
                case ModelInEvents.PictureBoxSelected:
                    handler = new PictureBoxSelectorSelectEventHandler(_model);
                    break;
            }
            return handler;
        }
    }
}
