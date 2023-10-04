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
        void SendEvent(TOutEvent e);
        void ReceiveEvent(TInEvent e);
    }

    public interface IEventHandler<TEvent, TEventParticipant>
    {
        void Handle(TEvent e, TEventParticipant eventParticipant);
    }
}
