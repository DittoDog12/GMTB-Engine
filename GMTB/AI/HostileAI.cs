using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB.AI
{
    class HostileAI : AllAI
    {
        #region Constructor
        public HostileAI()
        {

        }
        #endregion

        #region Methods
        public override void Update()
        {
            base.Update();

            // State controller
            Idle();
            FollowPlayer();
            Search();     
        }
        public virtual void Idle()
        {
            // Idle walk
        }
        public void FollowPlayer()
        {
            // Home in on mPlayerPos
        }
        public void Search()
        {
            // When player out of sight
            // Look in last mPlayerPos
            // If no collision after x seconds, return to idle
        }
        public override void Collision()
        {
            // grab Player
        }
        #endregion
    }
}
