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
        protected int mSpeed;
        protected Texture2D mTexture;
        protected string mTexturename;
        protected Vector3 mPosition;
        #endregion

        #region Accessors
        public Texture2D aTexture
        {
            set { mTexture = value; }
        }
        public string aTexturename
        {
            get { return mTexturename; }
        }
        #endregion

        #region Constructor
        #endregion

        #region Methods
        public virtual void Update()
        {

        }
        #endregion
    }
}
