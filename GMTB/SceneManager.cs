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
        #region Data Members
        private List<IEntity> mEntities;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        #endregion

        #region Constructor
        public SceneManager(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            // Initialise Entity List
            mEntities = new List<IEntity>();
            Content = content;
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
            mEntities.ForEach(IEntity => IEntity.setPos(x, y));

        }
        public void Update(GameTime gameTime)
        {
            mEntities.ForEach(IEntity => IEntity.Update(gameTime));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Call draw method for each Entity
            mEntities.ForEach(IEntity => IEntity.Draw(spriteBatch));
        }
        #endregion
    }
}
