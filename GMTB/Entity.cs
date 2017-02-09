﻿using System;
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
        protected bool mCollidable;
        protected string mDirection;

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;

        //--Hitbox for Collision Detection
        public Rectangle HitBox
        {
            get { return new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height); }
        }
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
        public bool Collidable
        {
            get { return mCollidable; }
        }
        #endregion

        #region Constructor
        public Entity(int pXpos, int pYpos)
        {
            mPosition.X = pXpos;
            mPosition.Y = pYpos;
            mCollidable = false;
        }
        #endregion

        #region Methods
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
            spriteBatch.End();
        }
        public virtual void Collision()
        {
            
        }

        public virtual bool CheckCollision(IEntity pObject)
        {
            bool rtnval = false;
            return rtnval;
        }
        #endregion
    }
}
