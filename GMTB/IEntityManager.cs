using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface IEntityManager
    {
        #region Accessors
        List<IEntity> Entities { get; }
        #endregion

        #region Methods
        void Update(GameTime gameTime);
        void NewPlayer(int pXpos, int pYpos, PlayerIndex pPlayerNum);
        void Ball(int pXpos, int pYpos);
    #endregion
    }
}
