using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public class AllAI : AnimatingEntity, IAI
    {
        #region Data Members
        protected Vector2 mPlayerPos;
        protected bool mPlayerVisible;
        protected string mState;
        protected string mTexturePath;
        protected bool mScare;
        #endregion

        #region Accessors
        public Vector2 PlayerPos
        {
            set { mPlayerPos = value; }
        }
        public bool PlayerVisible
        {
            set { mPlayerVisible = value; }
        }
        public string State
        {
            get { return mState; }
        }
        public bool Scare
        {
            get { return mScare; }
            set { mScare = value; }
        }
        #endregion

        #region Constructor
        public AllAI()
        {
            mPlayerVisible = true;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public bool CollisionChecker()
        {
            bool rtnVal = false;

            return rtnVal;
        }

        public override void Collision(object source, CollisionEvent args)
        {

        }

        public virtual void Idle()
        {

        }
        #endregion
    }
}
