using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    class HostileAI : AllAI, Collidable
    {
        #region Data Members
        private string mState;
        private Vector2 mStartPos;
        private Vector2 mDistanceToDest;
        private float ChaseTime;
        private float SearchTime;
        private float ActivityTimer;
        private float SearchTimer;
        #endregion

        #region Constructor
        public HostileAI()
        {
            mState = "Idle";
            mSpeed = 3f;
            mVelocity.Y = mSpeed;
            interval = 100f;
            ChaseTime = 2000f;
            SearchTime = 2000f;
            mStartPos = mPosition;
            mUName = "AI";
            mCollidable = true;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            checkPlayerProx(gameTime);
            mPosition += mVelocity;

            if (mVelocity.X > 0)
                    mDirection = "Right";
                else if (mVelocity.X < 0)
                    mDirection = "Left";

            if (mVelocity.Y > 0)
                    mDirection = "Down";
                else if (mVelocity.Y < 0)
                    mDirection = "Up";

                // State controller
                switch (mState)
                {
                    case "Idle":
                        Idle();
                        break;
                    case "Follow":
                        FollowPlayer(gameTime);
                        break;
                    case "Search":
                        Search(gameTime);
                        break;
                    case "Reset":
                    Reset();
                    break;
                    default:
                        break;
                }

        }
        public override void Idle()
        {
            // Idle walk

            if (mPosition.X <= 160 || mPosition.X >= 670)
                mVelocity.X *= -1;
            if (mPosition.Y <= 150 || mPosition.Y >= 285)
                mVelocity.Y *= -1;
        }
        public void FollowPlayer(GameTime gameTime)
        {
            ActivityTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            mDistanceToDest = mPlayerPos - mPosition;
            mDistanceToDest.Normalize();

            mVelocity = mDistanceToDest * mSpeed;

            if (ActivityTimer >= ChaseTime)
            {
                mState = "Search";
                ActivityTimer = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                SearchTimer = 0f;
                mDirection = "Left";
                mVelocity.Y = 0;
                mVelocity.X = 0;
            }

        }
        public void Search(GameTime gameTime)
        {
            SearchTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            ActivityTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (SearchTimer >= 490f && SearchTimer <= 510f)
                mDirection = "Up";
            if (SearchTimer >= 990f && SearchTimer <= 1010f)
                mDirection = "Right";
            if (SearchTimer >= 1490f && SearchTimer <= 1510f)
                mDirection = "Down";

            if (ActivityTimer >= SearchTime)
            {
                mDistanceToDest = mStartPos - mPosition;
                mDistanceToDest.Normalize();
                mState = "Reset";
            }
                

        }
        public override void Collision()
        {
            RoomManager.getInstance.Room = "Backgrounds/GameOver";
            Global.GameOver = true;
        }
        public void checkPlayerProx(GameTime gameTime)
        {
            if(mState == "Idle")
            {
                if (mPlayerPos.X >= Kernel.ScreenWidth / 2)
                {
                    mState = "Follow";
                    ActivityTimer = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
        }
        public void Reset()
        {
            mVelocity = mDistanceToDest;
            if (mPosition == mStartPos)
            {
                mState = "Idle";
                mVelocity.X = 0;
                mVelocity.Y = mSpeed;
            }
        }
        #endregion
    }
}
