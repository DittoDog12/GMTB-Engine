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
        public Player(int pXpos, int pYpos) : base(pXpos, pYpos)
        {
            mTexturename = "Player Images/JFW";
            mSpeed = 3;

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
                    mTexturename = "Player Images/JBW";
                    CurrentFrame++;
                    break;
                case "Left":
                    mPosition.X -= mSpeed;
                    mTexturename = "Player Images/JLW";
                    CurrentFrame++;
                    break;
                case "Down":
                    mPosition.Y += mSpeed;
                    mTexturename = "Player Images/JFW";
                    CurrentFrame++;
                    break;
                case "Right":
                    mPosition.X += mSpeed;
                    mTexturename = "Player Images/JRW";
                    CurrentFrame++;
                    break;
                default:
                    CurrentFrame = 0;
                    break;
            }

        }
        #endregion

    }
}
