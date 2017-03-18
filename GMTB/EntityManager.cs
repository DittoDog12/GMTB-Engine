using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GMTB.AI;


namespace GMTB
{
    // Declare Generic class for entity types
    

    public class EntityManager : IEntityManager 
    {
        #region Data Members
        // Create Master List for all entities
        public List<IEntity> mEntities;
        // Create UID 
        private int UID;
        #endregion

        #region Constructor
        public EntityManager()
        {
            // Initialise Lists and Content Manager Reference
            mEntities = new List<IEntity>();
            // Set UID counter to 0 for first object
            UID = 0;
        }
        #endregion

        #region Methods
        public IEntity newEntity<T>() where T : IEntity, new()
        {
            // Create an entity of the type specifed by the Kernel
            IEntity createdEntity = new T();
            // Store in the list
            mEntities.Add(createdEntity);
            // Set the entities UID
            createdEntity.setVars(UID);
            // Increment the UID counter
            UID++;
            // Return the new entity to the kernel
            return createdEntity;
        }
        public IEntity newEntity<T>(PlayerIndex pPlayerNum) where T : IEntity, new()
        {
            // Same as above but allow for the Player ID for controls
            IEntity createdEntity = new T();
            mEntities.Add(createdEntity);
            createdEntity.setVars(UID, pPlayerNum);
            UID++;
            return createdEntity;
        }

        public void removeEntity(int uid)
        {
            for (int i = 0; i <mEntities.Count; i++)
            {
                if(mEntities[i].UID == uid)
                {
                    mEntities.RemoveAt(i);
                    mEntities[i] = null;
                }
            }
        } 
        #endregion
    }
}
