using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    abstract class AnimatingEntity : Entity
    {
        #region Data Members
        // Sets frame information for the Draw Method to read the spritesheets
        protected int Frames;
        protected int CurrentFrame;
        protected int Rows;
        protected int Columns;

        // Row and Column sizes for Hitbox
        private int column;
        private int row;

        // New hitbox to override default one inherited from Entity, uses special sprite sheet details
        public new Rectangle HitBox
        {
            get { return new Rectangle((int)mPosition.X, (int)mPosition.Y, column, row); }
        }
        #endregion

        #region Constructor
        public AnimatingEntity()
        {
            // Initialise Frame information
            Frames = 4;
            CurrentFrame = 0;
            Rows = 1;
            Columns = 4;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            // Used to reset the animation when it reaches the end of the spritesheet
            if (CurrentFrame == Frames)
                CurrentFrame = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            // Override normal draw method with specialised animating one

            // Calculate size of each animation frame
            int width = mTexture.Width / Columns;
            int height = mTexture.Height / Rows;
            row = (int)((float)CurrentFrame / (float)Columns);
            column = CurrentFrame % Columns;

            // Position selection around frame of spritesheet
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, width, height);

            Console.WriteLine("Column");
            Console.WriteLine(column);

            // Run spritebatch update with each frame of the animation
            spriteBatch.Begin();
            spriteBatch.Draw(mTexture, destinationRectangle, sourceRectangle, Color.AntiqueWhite);
            spriteBatch.End();

            
        }
        #endregion

    }
}
