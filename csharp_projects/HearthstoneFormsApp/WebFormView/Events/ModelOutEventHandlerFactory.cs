using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameModel.Events;
using GameModel.Events.Enums;

namespace WebFormView.Events
{
    internal class ModelOutEventHandlerFactory : MvcModelOutEventHandlerFactory
    {
        protected MvcWebFormView _view;

        public ModelOutEventHandlerFactory(MvcWebFormView view)
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
                
            }
            return handler;
        }
    }
}
