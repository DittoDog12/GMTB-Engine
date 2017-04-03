using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public class HighLevelAI : HostileAI
    {
        #region Constructor
        public HighLevelAI()
        {
            mProximityBoxSize = new Vector2(250, 250);
            ChaseTime = 2000f;
            SearchTime = 2000f;
            mCollidable = true;
            mSpeed = 3f;
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
