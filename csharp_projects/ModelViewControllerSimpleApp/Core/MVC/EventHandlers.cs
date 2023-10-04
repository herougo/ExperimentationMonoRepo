using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    class ModelInEventHandler : IEventHandler<ModelInEvent, MvcModel>
    {
        public void Handle(ModelInEvent e, MvcModel eventParticipant)
        {

        }
    }

    class ModelOutEventHandler : IEventHandler<ModelOutEvent, MvcController>
    {
        public void Handle(ModelOutEvent e, MvcController eventParticipant)
        {

        }
    }
    class ViewOutEventHandler : IEventHandler<ViewOutEvent, MvcController>
    {
        public void Handle(ViewOutEvent e, MvcController eventParticipant)
        {

        }
    }
}
