using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public interface IEntity
    {
        Texture2D aTexture { set; }
        String aTexturename { get; }
        void Update();
    }
}
