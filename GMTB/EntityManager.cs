using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Pong;

namespace GMTB
{
    public class EntityManager : IEntityManager
    {
        #region Data Members
        // Create Master List for all entities
        public List<IEntity> mEntities;
        // Create Sublists for each Entity Type 
        //public List<IEntity> mPlayers;
        //public List<IEntity> mWorldObjects;
        // Create Reference to the Content Manager
        Microsoft.Xna.Framework.Content.ContentManager Content;  
        #endregion

        #region Accessors
        public List<IEntity> Entities
        {
            get { return mEntities; }
        }
        #endregion

        #region Constructor
        public EntityManager(Microsoft.Xna.Framework.Content.ContentManager pContent)
        {
            // Initialise Lists and Content Manager Reference
            Content = pContent;
            mEntities = new List<IEntity>();
            //mPlayers = new List<IEntity>();
            //mWorldObjects = new List<IEntity>();
        }
        #endregion

        #region Methods
        // ----------- Cannot add multiple lists to master list, duplicates are created, change asap ---------- //
        public void ApplyCommon(/**List<IEntity> OtherList**/)
        {
            // Applies Common factors to every entity
            // Applies Texture to each entity using Class Specified texture name
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            // Adds contents of additional lists to the Master List
            //mEntities.AddRange(OtherList);
            // Set UID
            for (int i = 0; i < mEntities.Count; i++)
            {
                mEntities[i].UID = i;
            }
        }

        public void Update(GameTime gameTime)
        {
            // Reaply textures for Animating Entities only
            mEntities.ForEach(AnimatingEntity => AnimatingEntity.aTexture = Content.Load<Texture2D>(AnimatingEntity.aTexturename));
            // Call All Entities Update
            mEntities.ForEach(IEntity => IEntity.Update(gameTime));
            // Call Collision Check
            CheckCollision();
        }

        public void NewPlayer(int pXpos, int pYpos, PlayerIndex pPlayerNum)
        {
            // Adds a new Player to the Player List
            //mPlayers.Add(new Player(pXpos, pYpos, pPlayerNum));
            mEntities.Add(new Player(pXpos, pYpos, pPlayerNum));
            // Calls Common factor application method
            //ApplyCommon(mPlayers);
            ApplyCommon();
        }

        public void Ball(int pXpos, int pYpos)
        {
            // Adds a new Ball to the World Object List
            // mWorldObjects.Add(new Ball(pXpos, pYpos));
            mEntities.Add(new Ball(pXpos, pYpos));
            // Calls Common factor application method
            //ApplyCommon(mWorldObjects);
            ApplyCommon();
        }

        public void CheckCollision()
        {
            // Main Collision Detection
            // 1 - Run through each Object in the Master Entity List
            for (int i = 0; i < mEntities.Count; i++)
            {
                // 2 - Continue only if Current Master List Entry is Collidable
                if (mEntities[i].Collidable == true)
                {
                    // 3 - Call Player's Check Collision Method, pass Current Master List Entry
                    //bool Collide = mPlayers[0].CheckCollision(mEntities[i]);
                    //bool Collide1 = mPlayers[1].CheckCollision(mEntities[i]);
                    bool Collide = mEntities[0].CheckCollision(mEntities[i]);
                    bool Collide1 = mEntities[1].CheckCollision(mEntities[i]);



                    // 4 - If Player confirms Collsion has occured, call Current Master List Entries Collision Method
                    if (Collide == true || Collide1 == true)
                    {
                        mEntities[i].Collision();
                    }
                }
                
            }
            
        }
        


            
        #endregion
    }
}
