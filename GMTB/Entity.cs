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
        //--Movement
        protected int mSpeed;
        protected Vector2 mPosition;

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;
        protected int Frames;
        protected int CurrentFrame;
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
        public Entity()
        {
            Frames = 4;
            CurrentFrame = 0;
        }
        #endregion

        #region Methods
        public virtual void Update()
        {
            if (CurrentFrame == Frames)
                CurrentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate size of each animation frame
            int width = mTexture.Width / 4;
            int height = mTexture.Height;
            int row = (int)((float)CurrentFrame / (float) 4);
            int column = CurrentFrame % 4;

            // Position selection around frame of spritesheet
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, width, height);
             
            // Run spritebatch update with each frame of the animation
            spriteBatch.Begin();
            spriteBatch.Draw(mTexture, destinationRectangle, sourceRectangle, Color.AntiqueWhite);
            spriteBatch.End();
        }
        #endregion
    }
}
