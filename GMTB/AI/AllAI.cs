using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public class AllAI : IAI
    {
        #region Data Members
        private bool mReact;
        private Vector2 mPlayerPos;

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
        #endregion

        #region Constructor
        public AllAI()
        {
            mReact = false;
        }
        #endregion

        #region Methods
        public virtual void Update()
        {
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

        public virtual void Collision()
        {

        }

        public virtual void Idle()
        {

        }
        #endregion
    }
}
