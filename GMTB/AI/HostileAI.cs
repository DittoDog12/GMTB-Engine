using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public class HostileAI : AllAI, Collidable
    {
        #region Data Members
        protected Vector2 mStartPos;
        protected Vector2 mDistanceToDest;
        protected float ChaseTime;
        protected float SearchTime;
        protected float ActivityTimer;
        protected float SearchTimer;
        #endregion

        #region Constructor
        public HostileAI()
        {
            mState = "Idle";
            mSpeed = 3f;
            mVelocity.Y = mSpeed;
            interval = 100f;
            mStartPos = mPosition;
            mUName = "AI";
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
        public virtual void FollowPlayer(GameTime gameTime)
        {
            ActivityTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            mDistanceToDest = mPlayerPos - mPosition;
            mDistanceToDest.Normalize();

            mVelocity = mDistanceToDest * mSpeed;

            if (ActivityTimer >= ChaseTime || !mPlayerVisible)
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
            if (SearchTimer >= (SearchTime / 4 - 10) && SearchTimer <= (SearchTime / 4 + 10))
                mDirection = "Up";
            if (SearchTimer >= (SearchTime / 2 - 10) && SearchTimer <= (SearchTime / 2 + 10))
                mDirection = "Right";
            if (SearchTimer >= (SearchTime - ((SearchTime / 4) - 10)) && 
                SearchTimer <= (SearchTime - ((SearchTime / 4) + 10)))
                mDirection = "Down";

            if (ActivityTimer >= SearchTime)
            {
                
                mState = "Reset";
            }
                

        }
        public override void Collision(object source, CollisionEvent args)
        {
            if (args.Entity == this)
            {
                RoomManager.getInstance.Room = "Backgrounds/GameOver";
                Global.GameOver = true;
            }
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
            mDistanceToDest = mStartPos - mPosition;
            mDistanceToDest.Normalize();
            mVelocity = mDistanceToDest * mSpeed;
            if (mPosition == mStartPos)
            {
                mState = "Idle";
                mVelocity.X = 0;
                mVelocity.Y = mSpeed;
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            CollisionManager.getInstance.unSubscribe(Collision, this);
        }
        public override void sub()
        {
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion
    }
}
