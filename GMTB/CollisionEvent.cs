using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    public class CollisionEvent : EventArgs
    {
        public Collidable Entity;
        public CollisionEvent(Collidable entity)
        {
            Entity = entity;
        }
        public CollisionEvent()
        {

        }
    }
}
