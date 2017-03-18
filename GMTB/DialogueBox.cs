﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GMTB
{
    /// <summary>
    /// Method for drawing text on screen, holds the position and SpriteFont to use
    /// </summary>
    public class DialogueBox : IDialogue
    {
        #region Data Members
        Microsoft.Xna.Framework.Content.ContentManager Content;
        // Create SpriteFont
        private SpriteFont mFont;
        private Vector2 mPosition;
        private string mDisplay;
        private bool mActive;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if(mActive)
            {
                spriteBatch.DrawString(mFont, mDisplay, mPosition, Color.White);
               // Debug.WriteLine("Dialogue: " + mDisplay);
                mActive = false;
            }
            
        }
        public void Display(string Display)
        {
            mDisplay = Display;
            mActive = true;
        }

        #endregion
    }
}
