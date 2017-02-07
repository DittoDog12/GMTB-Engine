using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public class Entity : IEntity
    {
        #region Data Members
        //--Key Variables
        protected int mUID;
        protected string mUName;
        //--Movement
        protected int mSpeed;
        protected Vector2 mPosition;

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;
        #endregion

        #region Accessors
        public int UID
        {
            get { return mUID; }
        }
        public string UName
        {
            get { return mUName; }
        }
        public Texture2D aTexture
        {
            set { mTexture = value; }
        }
        public string aTexturename
        {
            get { return mTexturename; }
        }
        public Vector2 Position
        {
            get { return mPosition; }
        }
        #endregion

        #region Constructor
        public Entity(int pXpos, int pYpos)
        {
            mPosition.X = pXpos;
            mPosition.Y = pYpos;

        }
        #endregion

        #region Methods
        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
            spriteBatch.End();
        }
        #endregion
    }
}
