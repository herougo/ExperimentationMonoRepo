﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.MVC;
using GameModel.Events.Enums;

namespace GameModel.Events
{
    public abstract class ModelOutEvent : MvcModelOutEvent
    {
        public abstract ModelOutEvents GetEnum();
    }
}