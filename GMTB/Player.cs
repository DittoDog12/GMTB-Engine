using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    class Player : MovingEntity
    {
        #region Data Members

        #endregion

        #region Constructor
        public Player() : base()
        {
            mTexturename = "squaresheet";
            mSpeed = 3;
            mPosition.X = Game1.ScreenWidth / 2;
            mPosition.Y = Game1.ScreenHeight / 2;

        }
        #endregion

        #region Methods
        public override void Update()
        {
            base.Update();
            mDirection = Input.GetKeyboardInputDirection(PlayerIndex.One);
            switch (mDirection)
            {
                case "Up":
                    mPosition.Y -= mSpeed;
                    CurrentFrame++;
                    break;
                case "Left":
                    mPosition.X -= mSpeed;
                    CurrentFrame++;
                    break;
                case "Down":
                    mPosition.Y += mSpeed;
                    CurrentFrame++;
                    break;
                case "Right":
                    mPosition.X += mSpeed;
                    CurrentFrame++;
                    break;
                default:
                    break;
            }

        }
        #endregion

    }
}
