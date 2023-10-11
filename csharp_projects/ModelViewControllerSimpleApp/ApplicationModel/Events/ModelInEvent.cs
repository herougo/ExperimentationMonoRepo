using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.MVC;
using ApplicationModel.Events.Enums;

namespace ApplicationModel.Events
{
    public abstract class ModelInEvent : MvcModelInEvent
    {
        public abstract ModelInEvents GetEnum();
    }
}
