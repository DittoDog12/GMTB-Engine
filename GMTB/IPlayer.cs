using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface IPlayer
    {
        Rectangle HitBox { get; }
        Vector2 Position { get; set; }
        bool Visible { get; set; }
        void Collision(object source, CollisionEvent args);
        void CollisionHide();
    }
}
