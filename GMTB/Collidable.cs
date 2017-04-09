using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface Collidable
    {
        Rectangle HitBox { get; }
        string UName { get; }
        void Collision(object source, CollisionEvent args);
    }
}
