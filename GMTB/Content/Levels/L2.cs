using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Door
            createdEntity = EntityManager.getInstance.newEntity<Door>();
            SceneManager.getInstance.newEntity(createdEntity, 260, 285);
            createdEntity.setVars("L1", new Vector2(160, 240));
        }

        public override List<int> Exit()
        {
            base.Exit();
            return Removables;
        }
        #endregion
    }
}
