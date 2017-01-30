using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    class Player : Entity
    {
        #region Data Members
        private string mDirection;
        #endregion

        #region Constructor
        public Player()
        {
            mTexturename = "foward1";
            mSpeed = 3;
        }
        #endregion

        #region Methods
        public override void Update()
        {
            mDirection = Input.GetKeyboardInputDirection(PlayerIndex.One);
            switch (mDirection)
            {
                case "Up":
                    mPosition.Y += mSpeed;
                    break;
                case "Left":
                    mPosition.X -= mSpeed;
                    break;
                case "Down":
                    mPosition.Y -= mSpeed;
                    break;
                case "Right":
                    mPosition.X += mSpeed;
                    break;
            }

        }
        #endregion

    }
}
