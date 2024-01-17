using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.MVC;
using WebFormView.Events.Enums;

namespace WebFormView.Events
{
    public abstract class ViewOutEvent : MvcViewOutEvent
    {
        public abstract ViewOutEvents GetEnum();
    }
}
