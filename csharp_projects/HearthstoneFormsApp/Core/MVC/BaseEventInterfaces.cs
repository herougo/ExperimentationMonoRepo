using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public interface IEvent
    {

    }
    public interface IEventReceiver
    {
        void Receive(IEvent e);
    }

    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent e);
    }
}
