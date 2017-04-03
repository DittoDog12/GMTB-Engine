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
        private int[] BedPositions;
        #endregion

        #region Constructor
        public L1() : base()
        {
            bg = "Backgrounds\\SpawnRoomBackground";
            BedPositions = new int[3];
            BedPositions[0] = 160;
            BedPositions[1] = 255;
            BedPositions[2] = ScreenWidth / 2;

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            if (firstRun == true)
            {
                // Old Man
                createdEntity = EntityManager.getInstance.newEntity<FriendlyAI>("NPC/OldMan/");
                SceneManager.getInstance.newEntity(createdEntity, 290, 150);
                Removables.Add(createdEntity);

                //Martha
                createdEntity = EntityManager.getInstance.newEntity<HighLevelAI>("Enemy/Martha/");
                SceneManager.getInstance.newEntity(createdEntity, 640, ScreenHeight / 2);
                Removables.Add(createdEntity);
                MarthaID = createdEntity.UID;

                // Hiding Place
                for (int i = 0; i < BedPositions.Length; i++)
                {
                    createdEntity = EntityManager.getInstance.newEntity<HidingPlace>();
                    SceneManager.getInstance.newEntity(createdEntity, BedPositions[i], 150);
                    Removables.Add(createdEntity);
                }


                // Door
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, 450, 285);
                createdEntity.setVars("L2", new Vector2(240, 350));
                Removables.Add(createdEntity);

                firstRun = false;
            }
            else
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
            foreach (IEntity m in Removables)
                if (m.UID == MarthaID)
                {
                    IAI Martha = m as IAI;
                    MarthaStatus = Martha.State;
                }
            if (MarthaStatus == "Follow")
            {
                for (int i = 0; i < Removables.Count; i++)
                    if (Removables[i].UID == MarthaID)
                        Removables.Remove(Removables[i]);
            }
            return Removables;
        }
        #endregion
    }
}
