using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.AI;
using Microsoft.Xna.Framework;

namespace GMTB.Content.Levels
{
    class L1 : Level
    {
        #region Data Members
        private string MarthaStatus;
        private int MarthaID;
        #endregion

        #region Accessor
        public string MarthaStat
        {
            set { MarthaStatus = value; }
        }
        #endregion

        #region Constructor
        public L1() : base()
        {
            bg = "Backgrounds\\SpawnRoomBackground";
            
        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            if (firstRun == true)
            {
                // Old Man
                createdEntity = EntityManager.getInstance.newEntity<FriendlyAI>();
                SceneManager.getInstance.newEntity(createdEntity, ScreenWidth / 2, ScreenHeight / 2);
                Removables.Add(createdEntity);

                //Martha
                createdEntity = EntityManager.getInstance.newEntity<HighLevelAI>();
                SceneManager.getInstance.newEntity(createdEntity, 640, ScreenHeight / 2);
                Removables.Add(createdEntity);
                MarthaID = createdEntity.UID;

                // Hiding Place
                createdEntity = EntityManager.getInstance.newEntity<HidingPlace>();
                SceneManager.getInstance.newEntity(createdEntity, 160, 150);
                Removables.Add(createdEntity);

                // Door
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, 450, 285);
                createdEntity.setVars("L2", new Vector2(240, 350));
                Removables.Add(createdEntity);

                firstRun = false;
            }else
            {
                foreach (IEntity e in EntityManager.getInstance.Entities)
                    foreach (IEntity r in Removables)
                    if (e.UID == r.UID)
                        {
                            SceneManager.getInstance.newEntity(r, (int)r.DefaultPos.X, (int)r.DefaultPos.Y);
                            r.sub();
                        }
                            
            }
            
        }

        public override List<IEntity> Exit()
        {
            base.Exit();
            if (MarthaStatus == "Follow")
            {
                foreach (IEntity e in Removables)
                    if (e.UID == MarthaID)
                        Removables.Remove(e);
            }
            return Removables;
        }
        #endregion
    }
}
