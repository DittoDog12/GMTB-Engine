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
            // Old Man
            createdEntity = EntityManager.getInstance.newEntity<FriendlyAI>();
            SceneManager.getInstance.newEntity(createdEntity, ScreenWidth / 2, ScreenHeight / 2);
            Removables.Add(createdEntity.UID);
  
            //Martha
            createdEntity = EntityManager.getInstance.newEntity<HighLevelAI>();   
            SceneManager.getInstance.newEntity(createdEntity, 640, ScreenHeight / 2);
            Removables.Add(createdEntity.UID);
            MarthaID = createdEntity.UID;

            // Hiding Place
            createdEntity = EntityManager.getInstance.newEntity<HidingPlace>();
            SceneManager.getInstance.newEntity(createdEntity, 160, 150);
            Removables.Add(createdEntity.UID);

            // Door
            createdEntity = EntityManager.getInstance.newEntity<Door>();
            SceneManager.getInstance.newEntity(createdEntity, 450, 285);
            createdEntity.setVars("L2", new Vector2(240, 350));
        }

        public override List<int> Exit()
        {
            base.Exit();
            if (MarthaStatus == "Follow")
            {
                foreach (int i in Removables)
                    if (i == MarthaID)
                        Removables.Remove(i);
            }
            return Removables;
        }
        #endregion
    }
}
