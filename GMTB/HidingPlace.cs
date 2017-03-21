using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    class HidingPlace : Entity, Collidable
    {
        #region Data Members
        private bool Hide;
        #endregion
        #region Constructor
        public HidingPlace()
        {
            mTexturename = "AdultsBedLong";
            mUName = "HidingPlace";
            Hide = false;
            Input.getInstance.SubscribeUse(OnUse);
        }
        #endregion

        #region Methods
        public override void Collision()
        {
            if (Hide)
            {
                CollisionManager.getInstance.currPlayer.Visible = false;
                Hide = false;
            }
               
        }
        public void OnUse(object source, InputEvent args)
        {
            Hide = true;
        }
        #endregion
    }
}
