using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace GMTB.Content.Levels
{
    class L3 : Level
    {
        #region Constructor
        public L3() : base()
        {
            bg = "Backgrounds\\MatronsOfficeBackground";
        }
        #endregion
        #region Methods
        public override void Initialise()
        {
            if (firstRun == true)
            {
                // Door
                createdEntity = EntityManager.getInstance.newEntity<Door>();
                SceneManager.getInstance.newEntity(createdEntity, 590, ScreenHeight / 2);
                createdEntity.setVars("L2", new Vector2(290, 300));
                Removables.Add(createdEntity);


                // Walls
                //Left
                wall = new InvisibleWall();
                wall.setVars(new Vector2(200, 125), new Vector2(10, 275));
                Walls.Add(wall);
                //right
                wall = new InvisibleWall();
                wall.setVars(new Vector2(620, 125), new Vector2(10, 275));
                Walls.Add(wall);
                //top
                wall = new InvisibleWall();
                wall.setVars(new Vector2(200, 125), new Vector2(420, 10));
                Walls.Add(wall);
                //bottom
                wall = new InvisibleWall();
                wall.setVars(new Vector2(200, 400), new Vector2(420, 10));
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
