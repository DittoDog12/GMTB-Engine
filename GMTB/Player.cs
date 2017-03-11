using System;
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
        private Vector2 mVelocity;
        private Input inputMan;
        #endregion

        #region Constructor
        public Player()
        {
            mSpeed = 5;
            inputMan = new Input(mSpeed);
            inputMan.AddListener(this.OnNewInput);
        }
        #endregion

        #region Methods
        public override void setVars(int uid, PlayerIndex pPlayer)
        {
            UID = uid;
            mPlayerNum = pPlayer;
            mUName = "Player";
            mTexturename = "Player Images/JFW";
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            inputMan.UpdateInput();
            // Movement controlled by timer
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                mPosition += mVelocity;
                switch (mDirection)
                {
                    case "Up":
                        mTexturename = "Player Images/JBW";
                        CurrentFrame++;
                        break;
                    case "Left":
                        mTexturename = "Player Images/JLW";
                        CurrentFrame++;
                        break;
                    case "Down":
                        mTexturename = "Player Images/JFW";
                        CurrentFrame++;
                        break;
                    case "Right":
                        mTexturename = "Player Images/JRW";
                        CurrentFrame++;
                        break;
                    case "stop":
                        CurrentFrame = 0;
                        break;
                    default:
                        break;
                }
                timer = 0f;
            }      
        }
        public void OnNewInput(object source, InputEvent args)
        {
            mVelocity = args.Velocity;
            mDirection = args.Direction;
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
