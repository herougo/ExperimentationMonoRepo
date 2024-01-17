using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class MvcGameModel
    {
        EventSender _eventSender;

        public MvcGameModel(EventSender eventSender) {
            _eventSender = eventSender;
        }

        public void SendEvent(IEvent e)
        {
            _eventSender.Send(e);
        }


    }
}
