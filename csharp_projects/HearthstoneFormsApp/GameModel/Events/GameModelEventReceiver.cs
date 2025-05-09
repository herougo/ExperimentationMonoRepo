using GameModel.Events;
using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel.Events
{
    public class GameModelEventReceiver : IEventReceiver
    {
        ModelInEventHandlerFactory _modelInEventHandlerFactory;

        public GameModelEventReceiver(MvcGameModel model)
        {
            _modelInEventHandlerFactory = new ModelInEventHandlerFactory(model);
        }

        public void Receive(IEvent e)
        {
            ModelInEventHandler handler = _modelInEventHandlerFactory.GetEventHandler(e);
            handler.Handle((MvcModelInEvent)e);
        }
    }
}
