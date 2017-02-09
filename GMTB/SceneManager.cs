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
        // Create Reference to the Entity Manager
        IEntityManager EManager;
        #endregion

        #region Constructor
        public SceneManager(IEntityManager pEMan)
        {
            // Initialise Reference to the Entity Manager
            EManager = pEMan;
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            // Call draw method for each Entity in the Managers Master List
            EManager.Entities.ForEach(IEntity => IEntity.Draw(spriteBatch));
        }
        #endregion
    }
}
