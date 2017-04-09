using System;

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
