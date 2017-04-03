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
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                base.Update(gameTime);
                mPosition.Y -= mSpeed;
            }
            timer = 0f;
        }
    }
}
