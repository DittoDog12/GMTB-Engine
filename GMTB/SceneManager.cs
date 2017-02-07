using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public class SceneManager : ISceneManager
    {
        #region Data Members
        IEntityManager EManager;
        #endregion

        #region Constructor
        public SceneManager(IEntityManager pEMan)
        {
            EManager = pEMan;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            EManager.Entities.ForEach(IEntity => IEntity.Draw(spriteBatch));
        }
        #endregion
    }
}
