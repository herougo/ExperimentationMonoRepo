using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    abstract class ModelInEvent : IEvent<ModelInEventHandler>
    {
        public abstract ModelInEventHandler GetHandler();
    }

    abstract class ModelOutEvent : IEvent<ModelOutEventHandler>
    {
        public abstract ModelOutEventHandler GetHandler();
    }
    internal abstract class ViewOutEvent : IEvent<ViewOutEventHandler>
    {
        public abstract ViewOutEventHandler GetHandler();
    }
}
