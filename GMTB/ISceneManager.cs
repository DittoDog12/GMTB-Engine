using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public interface ISceneManager
    {
        #region Accessors
        List<IEntity> Entities { get; }
        #endregion

        #region Methods
        void newEntity(IEntity createdEntity, int x, int y);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        #endregion
    }
}
