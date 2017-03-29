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
        int UID { get; set; }
        string UName { get; }
        Texture2D aTexture { set; }
        String aTexturename { get; }
        Vector2 Position { get; }
        bool Collidable { get; }
        bool Visible { get; }
        #endregion

        #region Methods
        void setVars(int uid);
        void setVars(int uid, PlayerIndex pPlayer);
        void setVars(string tRoom, Vector2 playerStart);
        void setPos(int x, int y);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Destroy();
        #endregion
    }
}
