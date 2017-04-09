using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GMTB.Content.Levels
{
    class L2 : Level
    {
        #region Constructor
        public L2()
        {
            bg = "Backgrounds\\PrototypeBackgroundMarthasRoom";
        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            if(firstRun == true)
            {
                // Door
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, 260, 285);
                createdEntity.setVars("L1", new Vector2(160, 240));
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
            return Removables;
        }
        #endregion
    }
}
