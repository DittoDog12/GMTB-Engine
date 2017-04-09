using System;

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
