using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GMTB.Content.Levels
{
    class L5 : Level
    {
        #region Constructor
        public L5():base()
        {
            bg = "Backgrounds\\BoardRoomBackground";
        }
        #endregion
        #region Methods
        public override void Initialise()
        {
            if (firstRun == true)
            {
                // Door - south hallway
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, 575, ScreenHeight/ 2);
                createdEntity.setVars("L4", new Vector2(100, 150));
                Removables.Add(createdEntity);

                // Walls
                //Left
                wall = new InvisibleWall();
                wall.setVars(new Vector2(190, 125), new Vector2(10, 235));
                Walls.Add(wall);
                //right
                wall = new InvisibleWall();
                wall.setVars(new Vector2(610, 125), new Vector2(10, 235));
                Walls.Add(wall);
                //top
                wall = new InvisibleWall();
                wall.setVars(new Vector2(190, 125), new Vector2(420, 10));
                Walls.Add(wall);
                //bottom
                wall = new InvisibleWall();
                wall.setVars(new Vector2(190, 360), new Vector2(420, 10));
                Walls.Add(wall);

                //fireplace
                wall = new InvisibleWall();
                wall.setVars(new Vector2(360, 135), new Vector2(75, 10));
                Walls.Add(wall);
            }
            else
            {

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
