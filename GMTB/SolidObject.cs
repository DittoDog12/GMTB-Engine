namespace GMTB
{
    class SolidObject : Entity, Collidable
    {
        #region Constructor
        public SolidObject()
        {
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion

        #region Methods
        public override void setVars(int uid, string path)
        {
            base.setVars(uid);
            mTexturename = "Game Items/" + path;

        }
        public override void Collision(object source, CollisionEvent args)
        {
            
        }
        #endregion
    }
}