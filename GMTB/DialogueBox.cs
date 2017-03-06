using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    public class DialogueBox : IDialogue
    {
        #region Data Members
        Microsoft.Xna.Framework.Content.ContentManager Content;
        // Create SpriteFont
        private SpriteFont mFont;
        private SpriteBatch spriteBatch;
        private Vector2 mPosition;
        #endregion

        #region Constructors
        public DialogueBox(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            
            Content = content;
            mFont = Content.Load<SpriteFont>("HudText");
            mPosition.X = 50;
            mPosition.Y = Kernel.ScreenHeight - 50;
        }
        #endregion

        #region Methods
        public void Initialise(SpriteBatch pSpriteBatch)
        {
            spriteBatch = pSpriteBatch;
        }
        public void Draw(string mDisplay)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(mFont, mDisplay, mPosition, Color.Black);
            spriteBatch.End();
        }

        #endregion
    }
}
