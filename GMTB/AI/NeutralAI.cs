using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    class NeutralAI : AllAI
    {
        public NeutralAI() : base()
        {

        }

        public override void setVars(int uid)
        {
            base.setVars(uid);
            mTexturename = "NPC/PatientZeldaForward";
        }

        public override void Update(GameTime gameTime)
        {
            FollowPlayer();
            base.Update(gameTime);
            switch (mDirection)
            {
                case "Left":
                    mTexturename = "NPC/PatientZeldaLeft";
                    break;
                case "Down":
                    mTexturename = "NPC/PatientZeldaForward";
                    break;
                case "Right":
                    mTexturename = "NPC/PatientZeldaRight";
                    break;
                case "stop":
                    CurrentFrame = 0;
                    break;
                default:
                    break;
            }
            mDirection = "stop";
        }
        public void FollowPlayer()
        {
            if (mPlayerPos.X > mPosition.X)
                mDirection = "Right";
            if (mPlayerPos.X < mPosition.X)
                mDirection = "Left";
            if (mPlayerPos.X == mPosition.X)
                mDirection = "Down";

        }
    }
}
