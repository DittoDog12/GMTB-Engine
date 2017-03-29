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
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion

        #region Methods
        public override void Collision(object source, CollisionEvent args)
        {
            if (args.Entity == this)
            {
                if (Hide)
                {
                    CollisionManager.getInstance.currPlayer.Visible = false;
                    Hide = false;
                }
            }
               
        }
        public void OnUse(object source, InputEvent args)
        {
            Hide = true;
        }
        public override void Destroy()
        {
            base.Destroy();
            CollisionManager.getInstance.unSubscribe(Collision, this);
        }
        #endregion
    }
}
