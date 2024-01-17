using Core.MVC;
using GameModel;
using GameModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormController
{
    public class MvcWebFormController
    {
        public MvcWebFormController() {
            EventSender modelEventSender = new EventSender();
            MvcGameModel model = new MvcGameModel(modelEventSender);
            ModelEventReceiver modelEventReceiver = new ModelEventReceiver(model);

        }
    }
}
