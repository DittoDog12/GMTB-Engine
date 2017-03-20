using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    class LevelManager
    {
        #region Data Members
        private static LevelManager Instance = null;
        #endregion

        #region Constructor
        private LevelManager() { }
        public static LevelManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new LevelManager();
                return Instance;
            }
        }
        #endregion

        #region Methods
        public void NewLevel(int LevelID)
        {
            // Remove Entities
            // Load new Background
            // Place New Door
        }

        private void LoadBackground()
        {
            RoomManager.getInstance.Room = "";
        }
        private void PlaceDoor()
        {
            IEntity createdEntity = EntityManager.getInstance.newEntity<Door>();
            SceneManager.getInstance.newEntity(createdEntity, 640, 640);
            createdEntity.setVars("Backgrounds/PrototypeBackgroundMarthasRoom", new Vector2(1, 1));
        }
        #endregion
    }
}
