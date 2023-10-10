using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MVC
{
    public abstract class ModelInEvent : IEvent
    {
        public abstract int GetEnumInt();
    }

    public abstract class ModelOutEvent : IEvent
    {
        public abstract int GetEnumInt();
    }
    public abstract class ViewOutEvent : IEvent
    {
        public abstract int GetEnumInt();
    }
}
