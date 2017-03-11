using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public class InputEvent : EventArgs
    {
        public Vector2 Velocity;
        public string Direction;

        public InputEvent(Vector2 newVelocity, string newDirection)
        {
            Velocity = newVelocity;
            Direction = newDirection;
        }
    }
}
