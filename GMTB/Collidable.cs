using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    interface Collidable
    {
        Rectangle HitBox { get; }
        string UName { get; }
        void Collision();
    }
}
