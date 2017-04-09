using System.Collections.Generic;

namespace GMTB.Content.Levels
{
    public abstract class Level
    {
        #region Data Members
        protected string lvlID;
        protected string bg;
        protected IEntity createdEntity;
        protected int ScreenWidth = Kernel.ScreenWidth;
        protected int ScreenHeight = Kernel.ScreenHeight;
        protected List<IEntity> Removables;
        protected bool firstRun = true;
        #endregion
        #region Accessors
        public string Background
        {
            get { return bg; }
        }
        public string LvlID
        {
            get { return lvlID; }
        }
        #endregion
        #region Constructor
        public Level()
        {
            Removables = new List<IEntity>();
            lvlID = GetType().Name.ToString();
        }
        #endregion
        #region Methods
        public abstract void Initialise();
        public virtual List<IEntity> Exit()
        {
            return Removables;
        }
        #endregion
    }
}
