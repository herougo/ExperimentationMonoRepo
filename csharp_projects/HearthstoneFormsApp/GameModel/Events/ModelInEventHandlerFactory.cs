using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameModel.Events.Enums;

namespace GameModel.Events
{
    internal class ModelInEventHandlerFactory : MvcModelInEventHandlerFactory
    {
        protected MvcGameModel _model;

        public ModelInEventHandlerFactory(MvcGameModel model)
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
                
            }
            return handler;
        }
    }
}
