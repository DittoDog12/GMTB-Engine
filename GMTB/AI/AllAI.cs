using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public class AllAI : AnimatingEntity, IAI
    {
        #region Data Members
        private bool mReact;
        protected Vector2 mPlayerPos;
        protected bool mPlayerVisible;

        #endregion

        #region Accessors
        public bool React
        {
            set { mReact = value; }
        }
        public Vector2 PlayerPos
        {
            set { mPlayerPos = value; }
        }
        public bool PlayerVisible
        {
            set { mPlayerVisible = value; }
        }
        #endregion

        #region Constructor
        public AllAI()
        {
            mReact = false;
            mPlayerVisible = true;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (mReact)
            {
                // Look at player
            }
        }

        public bool CollisionChecker()
        {
            bool rtnVal = false;

            return rtnVal;
        }

        public override void Collision()
        {

        }

        public virtual void Idle()
        {

        }
        #endregion
    }
}
