using Microsoft.Xna.Framework;

namespace GMTB
{
    class Item : Entity, Collidable, hasProximity
    {
        #region Data Members
        public bool Collected = false;
        public bool use = false;

        public virtual Rectangle ProximityBox
        {
            get
            {
                return new Rectangle((int)mPosition.X - mTexture.Width / 2, (int)mPosition.Y,
              mTexture.Width * 2, mTexture.Height * 2);
            }
        }
        #endregion

        #region Constructor
        public Item()
        {

        }
        #endregion

        #region Methods
        public void inProximity(object source, ProximityEvent args)
        {
            if (args.Entity == this)
            {
                if (use)
                {
                    Collected = true;
                    Destroy();
                    use = false;
                }
            }

        }

        public void OnUse(object source, InputEvent args)
        {
            use = true;
        }
        public override void Destroy()
        {
            base.Destroy();
            CollisionManager.getInstance.unSubscribe(Collision, this);
            ProximityManager.getInstance.unSubscribe(inProximity, this);

        }
        public override void sub()
        {
            if (!Collected)
            {
                CollisionManager.getInstance.Subscribe(Collision, this);
                ProximityManager.getInstance.Subscribe(inProximity, this);
            }  
        }
        #endregion
    }
}
