using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface IEntityManager
    {

        #region Methods
        IEntity newEntity<T>() where T : IEntity, new();
        IEntity newEntity<T>(PlayerIndex pPlayerNum) where T : IEntity, new();
        void removeEntity(int uid);
    #endregion
    }
}
