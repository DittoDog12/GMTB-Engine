﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    class LowLevelAI : HostileAI
    {
        #region Constructor
        public LowLevelAI()
        {
            mProximityBoxSize = new Vector2(50, 50);

            ChaseTime = 1000f;
            SearchTime = 1000f;
            mCollidable = true;
            interval = 100f;
        }
        #endregion


        #region Methods
        public override void setVars(int uid, string path)
        {
            base.setVars(uid);
            mTexturePath = path;
            mTexturename = mTexturePath + "Front";
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                base.Update(gameTime);
                switch (mDirection)
                {
                    case "Up":
                        mTexturename = mTexturePath + "Back";
                        CurrentFrame++;
                        break;
                    case "Left":
                        mTexturename = mTexturePath + "Left";
                        CurrentFrame++;
                        break;
                    case "Down":
                        mTexturename = mTexturePath + "Front";
                        CurrentFrame++;
                        break;
                    case "Right":
                        mTexturename = mTexturePath + "Right";
                        CurrentFrame++;
                        break;
                    case "stop":
                        CurrentFrame = 0;
                        break;
                    default:
                        break;
                }
                timer = 0f;
                mDirection = "stop";
            }

        }
        #endregion
    }
}
