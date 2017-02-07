using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    class MovingEntity : Entity
    {
        #region Data Members
        protected string mDirection;

        protected int Frames;
        protected int CurrentFrame;
        #endregion

        #region Constructor
        public MovingEntity(int pXpos, int pYpos) : base(pXpos, pYpos)
        {
            Frames = 4;
            CurrentFrame = 0;

        }

        public override void Update()
        {
            if (CurrentFrame == Frames)
                CurrentFrame = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Calculate size of each animation frame
            int width = mTexture.Width / 4;
            int height = mTexture.Height;
            int row = (int)((float)CurrentFrame / (float)4);
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
