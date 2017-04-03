using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public interface IAI
    {
        Vector2 PlayerPos { set; }
        bool PlayerVisible { set; }
        string State { get; }
        void Update(GameTime gameTime);

        bool CollisionChecker();

        void Idle();
    }
}
