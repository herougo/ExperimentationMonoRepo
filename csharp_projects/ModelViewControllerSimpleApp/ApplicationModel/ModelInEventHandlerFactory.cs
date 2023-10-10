using Core.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationModel
{
    internal class ModelInEventHandlerFactory : MvcModelInEventHandlerFactory
    {
        public override ModelInEventHandler GetEventHandler(IEvent e)
        {
            ModelInEvent eTyped = (ModelInEvent)e;
            ModelInEvent enumInt = e.GetEnum();
            switch (enumInt)
            {

            }
        }
    }
}
