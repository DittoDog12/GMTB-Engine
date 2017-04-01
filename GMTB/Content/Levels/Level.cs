using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Content.Levels
{
    public abstract class Level
    {
        #region Data Members
        protected string bg;
        protected IEntity createdEntity;
        protected int ScreenWidth = Kernel.ScreenWidth;
        protected int ScreenHeight = Kernel.ScreenHeight;
        protected List<int> Removables;
        #endregion
        #region Accessors
        public string Background
        {
            get { return bg; }
        }
        #endregion
        #region Constructor
        public Level()
        {
            Removables = new List<int>();
        }
        #endregion
        #region Methods
        public virtual void Initialise()
        {

        }
        public virtual List<int> Exit()
        {
            return Removables;
        }
        #endregion
    }
}
