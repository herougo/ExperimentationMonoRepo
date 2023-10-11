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

    public interface IEventParticipant<TInEvent, TOutEvent>
    {
        void ReceiveEvent(TInEvent e);
        void SendEvent(TOutEvent e);
    }

    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent e);
    }
}
