using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    class HidingPlace : Entity, Collidable
    {
        #region Constructor
        public HidingPlace()
        {
            mTexturename = "AdultsBedLong";
            mUName = "HidingPlace";
        }
        #endregion

        #region Methods
        public override void Collision()
        {
            CollisionManager.getInstance.currPlayer.Visible = false;
        }
        #endregion
    }
}
