﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public interface IDialogue
    {
        void Display(string Display);
        void Draw(SpriteBatch spritebatch);
    }
}
