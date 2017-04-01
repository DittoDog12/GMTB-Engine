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
        private List<IEntity> Removables;
        private List<Level> AllLoadedLevels;
        private bool firstRun = true;
        #endregion

        #region Constructor
        private LevelManager()
        {
            Removables = new List<IEntity>();
            AllLoadedLevels = new List<Level>();
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
                foreach (IEntity e in Removables)
                    EntityManager.getInstance.removeEntity(e.UID);
            }
            if (firstRun == true)
            {
                string openLevel = "GMTB.Content.Levels." + LevelID;
                currLevel = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(openLevel) as Level;
                AllLoadedLevels.Add(currLevel);
                firstRun = false;
            }
            else
            {
                bool newLevel = true;
                for (int i = 0; i < AllLoadedLevels.Count; i++)
                {
                    if (AllLoadedLevels[i].LvlID == LevelID)
                    {
                        currLevel = AllLoadedLevels[i];
                        newLevel = false;
                    }
                }

                if (newLevel == true)
                {
                    string openLevel = "GMTB.Content.Levels." + LevelID;
                    currLevel = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(openLevel) as Level;
                    AllLoadedLevels.Add(currLevel);
                }
            }
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
