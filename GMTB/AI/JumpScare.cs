using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    class JumpScare : HostileAI, Collidable
    {
        public JumpScare()
        {
            mUName = "JumpScare";
            mSpeed = 0.75f;
            interval = 75f;
            mState = "Follow";

            mScare = true;
        }
        public override void setVars(int uid, string path)
        {
            base.setVars(uid);
            mTexturePath = path;
            mTexturename = mTexturePath + "Front";
            mDirection = "Down";
        }
        public override void Update(GameTime gameTime)
        {
            if (mScare == true)
            {
                //mDistanceToDest = mPlayerPos - mPosition;
                //mDistanceToDest.Normalize();

                //mVelocity = mDistanceToDest * mSpeed;
                //base.Update(gameTime);
            }
            else
            {
                mSpeed = 0f;
            }
        }
    }
}
