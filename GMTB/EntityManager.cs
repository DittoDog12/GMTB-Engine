using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public class EntityManager : IEntityManager
    {
        #region Data Members
        public List<IEntity> mEntities;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        #endregion

        #region Accessors
        public List<IEntity> Entities
        {
            get { return mEntities; }
        }
        #endregion

        #region Constructor
        public EntityManager(Microsoft.Xna.Framework.Content.ContentManager pContent)
        {
            Content = pContent;
            mEntities = new List<IEntity>();
        }
        #endregion

        #region Methods

        public void Update(GameTime gameTime)
        {
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            mEntities.ForEach(IEntity => IEntity.Update());
        }

        public void Player(int pXpos, int pYpos)
        {
            mEntities.Add(new Player(pXpos, pYpos));
            ApplyTexture();
        }

        public void ApplyTexture()
        {
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
        }
            
        #endregion
    }
}
