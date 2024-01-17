using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class ModelInEventHandler : IEventHandler<MvcModelInEvent>
    {
        public abstract void Handle(MvcModelInEvent e);
    }

    public abstract class ModelOutEventHandler : IEventHandler<MvcModelOutEvent>
    {
        public abstract void Handle(MvcModelOutEvent e);
    }
    public abstract class ViewOutEventHandler : IEventHandler<MvcViewOutEvent>
    {
        public abstract void Handle(MvcViewOutEvent e);
    }
}
