using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    class HidingPlace : Entity, Collidable, hasProximity
    {
        #region Data Members
        private bool Hide;

        // Second Hitbox for proximity detection
        // Make the box twice as big as the texture and off set it by minus half the texture size
        public virtual Rectangle ProximityBox
        {
            get { return new Rectangle((int)mPosition.X - mTexture.Width / 2, (int)mPosition.Y - mTexture.Height / 2, 
                mTexture.Width *2, mTexture.Height *2); }
        }
        #endregion

        #region Constructor
        public HidingPlace()
        {
            mTexturename = "AdultsBedLong";
            mUName = "HidingPlace";
            Hide = false;
            Input.getInstance.SubscribeUse(OnUse);
            CollisionManager.getInstance.Subscribe(Collision, this);
            ProximityManager.getInstance.Subscribe(inProximity, this);
        }
        #endregion

        #region Methods
        public void inProximity(object source, ProximityEvent args)
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
            ProximityManager.getInstance.unSubscribe(inProximity, this);

        }
        #endregion
    }
}
