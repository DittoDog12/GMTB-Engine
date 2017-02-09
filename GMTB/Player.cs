﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    class Player : AnimatingEntity
    {
        #region Data Members
        private PlayerIndex mPlayerNum;

        
        #endregion

        #region Constructor
        public Player(int pXpos, int pYpos, PlayerIndex pPlayerNum) : base(pXpos, pYpos)
        {
            mTexturename = "Player Images/JFW";
            mSpeed = 1;
            mPlayerNum = pPlayerNum;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (mPlayerNum == PlayerIndex.One)
            {
                mDirection = Input.GetInput(PlayerIndex.One);
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
            if (mPlayerNum == PlayerIndex.Two)
            {
                mDirection = Input.GetInput(PlayerIndex.Two);
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
            

        }
        public override bool CheckCollision(IEntity pObject)
        {
            bool rtnval = false;
            if (HitBox.Intersects(pObject.HitBox))
            {
                rtnval = true;
            }
            return rtnval;
        }
        #endregion

    }
}
