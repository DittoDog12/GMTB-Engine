using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    public class ProximityEvent : EventArgs
    {
        public hasProximity Entity;
        public ProximityEvent(hasProximity entity)
        {
            Entity = entity;
        }

    }
}
