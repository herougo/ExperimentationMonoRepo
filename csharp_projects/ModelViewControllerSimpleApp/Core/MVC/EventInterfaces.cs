using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    interface IEvent<THandler>
    {
        THandler GetHandler();
    }

    interface IEventParticipant<TInEvent, TOutEvent>
    {
        void SendEvent(TOutEvent e);
        void ReceiveEvent(TInEvent e);
    }

    interface IEventHandler<TEvent, TEventParticipant>
    {
        void Handle(TEvent e, TEventParticipant eventParticipant);
    }
}
