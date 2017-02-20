using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.Pong
{
    class Ball : Entity
    {
        #region Data Members
        public Random randomNum;
        public Vector2 velocity;
        #endregion

        #region Constructor
        public Ball()
        {
            mTexturename = "BlueDoll";
            mCollidable = true;
            mSpeed = 2;
            randomNum = new Random();
            serve();
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime) 
        {
            mPosition += velocity * mSpeed;
            CheckWallCollision();
        }
        
        private void CheckWallCollision()
        {

            if (mPosition.X >= Kernel.ScreenWidth || mPosition.X <= 0)
            {
                serve();
            }
            if (mPosition.Y >= Kernel.ScreenHeight || mPosition.Y <= 0)
            {
                velocity.Y *= -1;
            }
        }

        private void serve()
        {
            mPosition.X = Kernel.ScreenWidth / 2;
            mPosition.Y = Kernel.ScreenHeight / 2;
            float rotation = (float)(Math.PI / 2 + (randomNum.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));
            velocity.X = (float)Math.Sin(rotation);
            velocity.Y = (float)Math.Cos(rotation);
            if (randomNum.Next(1, 3) == 2)
            {
                velocity.X *= -1;
            }
        }

        public override void Collision()
        {
            velocity.X *= -1;
        }
        #endregion
    }
}
