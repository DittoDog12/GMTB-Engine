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
        private IPlayer mPlayer;
        private List<Collidable> AllCollidables;
        #endregion

        #region Constructor
        private CollisionManager()
        {
            // Initialize AllCollidables list
            AllCollidables = new List<Collidable>();
            // Initialize Player list
            IdentifyPlayers();
            IdentifyCollidable();
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
            List<IEntity> mEntities = EntityManager.getInstance.Entities;
            // Store the players in a second list
            for (int i= 0; i < mEntities.Count; i++)
            {
                var asInterface = mEntities[i] as IPlayer;
                if (asInterface != null)
                    mPlayer = asInterface;

            }
        }

        public void IdentifyCollidable()
        {
            List<IEntity> mEntities = EntityManager.getInstance.Entities;
            for (int i = 0; i < mEntities.Count; i++)
            {
                var asInterface = mEntities[i] as Collidable;
                if (asInterface != null)
                    AllCollidables.Add(asInterface);
            }
        }
        public void Update()
        {
            // Load each Collidable Object
            for (int i = 0; i < AllCollidables.Count; i++)
            {
                // Compare Loaded object with Player
                if (mPlayer.HitBox.Intersects(AllCollidables[i].HitBox))
                {
                    // Trigger Collision methods
                    AllCollidables[i].Collision();
                    mPlayer.Collision(); 
                }
            }
        }
        #endregion


    }
}
