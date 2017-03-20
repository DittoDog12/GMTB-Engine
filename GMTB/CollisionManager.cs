using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    /// <summary>
    /// Main Collision detection manager, calls the Entities Collision Method in the event of a collision
    /// </summary>
    public class CollisionManager
    {
        #region Data Members
        private static CollisionManager Instance = null;
        // Create a Reference for all onscreen entities
        private List<IEntity> mEntities;
        private List<IEntity> mPlayers;
        #endregion

        #region Constructor
        private CollisionManager()
        {
            // Initialize Reference to existing list
            mEntities = EntityManager.getInstance.Entities;
            // Initialize Player list
            mPlayers = new List<IEntity>();
            IdentifyPlayers();
        }
        public static CollisionManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new CollisionManager();
                return Instance;
            }
        }
        #endregion

        #region Methods
        public void IdentifyPlayers()
        {
            // Store the players in a second list
            for (int i= 0; i < mEntities.Count; i++)
            {
                if (mEntities[i].UName == "Player")
                {
                    mPlayers.Add(mEntities[i]);
                }
            }
        }
        public void Update()
        {
            // Main Collision Detection
            // 1 - Run through each Object in the Master Entity List
            for (int i = 0; i < mEntities.Count; i++)
            {
                // 2 - Continue only if Current Master List Entry is Collidable
                if (mEntities[i].Collidable == true)
                {
                    for (int p = 0; p < mPlayers.Count; p++)
                    {
                        // 3 - Call Player's Check Collision Method, pass Current Master List Entry
                        bool Collide = mPlayers[p].CheckCollision(mEntities[i]);
                        // 4 - If Player confirms Collsion has occured, call Current Master List Entries Collision Method
                        if (Collide == true)
                        {
                            mEntities[i].Collision();
                            mPlayers[p].Collision();
                        }
                    } 
                }
            }
        }
        #endregion


    }
}
