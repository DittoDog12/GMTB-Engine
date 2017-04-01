using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMTB.Content.Levels;

namespace GMTB
{
    class LevelManager
    {
        #region Data Members
        private static LevelManager Instance = null;
        private Level currLevel;
        private List<int> Removables;
        #endregion

        #region Constructor
        private LevelManager()
        {
            Removables = new List<int>();
        }
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



        public void NewLevel(string LevelID)
        {
            if (currLevel != null)
            {
                Removables = currLevel.Exit();
                foreach (int i in Removables)
                    EntityManager.getInstance.removeEntity(SceneManager.getInstance.SceneGraph[i].UID);
            }
            string openLevel = "GMTB.Content.Levels." + LevelID;
            currLevel = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(openLevel) as Level;
            currLevel.Initialise();
            LoadBackground(currLevel.Background);
           
        }

        private void LoadBackground(string LevelBG)
        {
            RoomManager.getInstance.Room = LevelBG;
        }
        #endregion
    }
}
