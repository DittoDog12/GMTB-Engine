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
        #region Accessors
        int UID { get; }
        string UName { get; }
        Texture2D aTexture { set; }
        String aTexturename { get; }
        Vector2 Position { get; }
        #endregion

        #region Methods
        void Update();
        void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}
