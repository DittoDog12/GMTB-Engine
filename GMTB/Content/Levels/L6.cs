using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB.AI;

namespace GMTB.Content.Levels
{
    class L6 : Level
    {
        #region Constructor
        public L6() :base()
        {
            bg = "backgrounds\\SecondWardBackground";
        }
        #endregion
        #region Methods
        public override void Initialise()
        {
            if (firstRun == true)
            {
                // Neutral AI
                createdEntity = EntityManager.getInstance.newEntity<NeutralAI>("NPC/PatientZelda/");
                SceneManager.getInstance.newEntity(createdEntity, 40, 100);
                Removables.Add(createdEntity);

                // Door - South Hallway
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, (ScreenWidth / 2) - 5, 90);
                createdEntity.setVars("L4", new Vector2((ScreenWidth / 4) - 10, 330));
                Removables.Add(createdEntity);

                // Walls
                //Left
                wall = new InvisibleWall();
                wall.setVars(new Vector2(25, 75), new Vector2(10, 365));
                Walls.Add(wall);
                //right
                wall = new InvisibleWall();
                wall.setVars(new Vector2(740, 75), new Vector2(10, 365));
                Walls.Add(wall);
                //top left
                wall = new InvisibleWall();
                wall.setVars(new Vector2(25, 75), new Vector2(370, 10));
                Walls.Add(wall);
                //top right
                wall = new InvisibleWall();
                wall.setVars(new Vector2(420, 75), new Vector2(370, 10));
                Walls.Add(wall);
                //bottom
                wall = new InvisibleWall();
                wall.setVars(new Vector2(25, 440), new Vector2(715, 10));
                Walls.Add(wall);
            }
            else
            {

            }
        }
        public override List<IEntity> Exit()
        {
            return Removables;
        }
        #endregion
    }
}
