﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    interface IPlayer
    {
        Rectangle HitBox { get; }
        Vector2 Position { get; set; }
        void Collision();
    }
}
