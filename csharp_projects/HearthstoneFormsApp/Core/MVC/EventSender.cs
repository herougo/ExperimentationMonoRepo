using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public class EventSender
    {
        List<IEventReceiver> _receivers;

        public void AddReceiver(IEventReceiver receiver)
        {
            _receivers = new List<IEventReceiver>();
            _receivers.Add(receiver);
        }
        public void Send(IEvent e)
        {
            foreach (IEventReceiver receiver in _receivers)
            {
                receiver.Receive(e);
            }
        }
    }
}
