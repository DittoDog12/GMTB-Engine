using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    class JumpScare : AllAI , Collidable
    {
        public bool Scare;
        public JumpScare()
        {
            mSpeed = 5f;
            interval = 75f;
        }
        public override void setVars(int uid, string path)
        {
            base.setVars(uid);
            mTexturePath = path;
            mTexturename = mTexturePath + "Front";
        }
        public override void Update(GameTime gameTime)
        {
            if (Scare == true)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    base.Update(gameTime);
                    mPosition.Y -= mSpeed;
                }
                timer = 0f;
            }else
            {
                mSpeed = 0f;
                mPosition = new Vector2(100, 100);
            }

            
        }
    }
}
