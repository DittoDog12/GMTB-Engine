using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public class SceneManager : ISceneManager
    {
        /// <summary>
        /// Main Scene Manager, places everything on the screen and calls Draw methods
        /// </summary>
        #region Data Members
        private List<IEntity> mEntities;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        public static IDialogue DM;

        private Texture2D Background;
        #endregion

        #region Accessors
        public List<IEntity> Entities
        {
            get { return mEntities; }
        }
        #endregion

        #region Constructor
        public SceneManager(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            // Initialise Entity List
            mEntities = new List<IEntity>();
            Content = content;
            DM = new DialogueBox(Content);
            Global.DM = DM;
            Background = Content.Load<Texture2D>("Backgrounds/SpawnRoomBackground");
        }
        #endregion

        #region Methods
        public void newEntity(IEntity createdEntity, int x, int y)
        {
            // Add the new entity to the SceneManagers entity list
            mEntities.Add(createdEntity);
            // Apply the entities texture
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            // Set the entities initial position
            createdEntity.setPos(x, y);

        }
        public void Update(GameTime gameTime)
        {
            mEntities.ForEach(IEntity => IEntity.Update(gameTime));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            // Update Texture path for animating entity
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            // Call draw method for each Entity
            mEntities.ForEach(IEntity => IEntity.Draw(spriteBatch));
            if(Global.PauseInput)
                DM.Draw(spriteBatch);
            spriteBatch.End();
        }
        #endregion
    }
}
