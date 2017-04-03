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
            ChaseTime = 2000f;
            SearchTime = 2000f;
            mCollidable = true;
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion

        #region Methods
        public override void setVars(int uid)
        {
            base.setVars(uid);
            mTexturename = "Enemy/Matron/MFW";
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
                        mTexturename = "Enemy/Matron/MBW";
                        CurrentFrame++;
                        break;
                    case "Left":
                        mTexturename = "Enemy/Matron/MLW";
                        CurrentFrame++;
                        break;
                    case "Down":
                        mTexturename = "Enemy/Matron/MFW";
                        CurrentFrame++;
                        break;
                    case "Right":
                        mTexturename = "Enemy/Matron/MRW";
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
