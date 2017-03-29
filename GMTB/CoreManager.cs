using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace GMTB
{
    /// <summary>
    /// Manager to control all other Managers
    /// </summary>
    public class CoreManager
    {
        #region DataMembers
        private static CoreManager Instance = null;
        #endregion

        #region Constructor
        private CoreManager() { }
        public static CoreManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new CoreManager();
                return Instance;
            }
        }
        
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            if (!Global.GameOver)
            {
                SceneManager.getInstance.Update(gameTime);
                Input.getInstance.Update();
                Script.getInstance.Update(gameTime);
                AiManager.getInstance.Update();
                if(!Global.PauseInput)
                    CollisionManager.getInstance.Update();
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            SceneManager.getInstance.Draw(spriteBatch);
        }

        #endregion

    }
}
