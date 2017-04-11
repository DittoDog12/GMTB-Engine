using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{

    public class GameOver
    {
        #region Data Members
        Microsoft.Xna.Framework.Content.ContentManager Content;
        private Texture2D exitButton;
        private Vector2 exitPosition;

        MouseState mouseState;

        MouseState previousMouseState;
        #endregion

        #region Constructor
        public GameOver()
        {
            Content = Global.Content;
        }
        #endregion

        #region Methods
        public void Initialize(SpriteBatch spriteBatch)
        {
            RoomManager.getInstance.Room = "Backgrounds/GameOver";
            // create Exit button, positioned center, near the bottom
            exitPosition = new Vector2(Kernel.ScreenWidth / 2, Kernel.ScreenHeight - 50);
            exitButton = Content.Load<Texture2D>("Exit");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(exitButton, exitPosition, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                MouseClicked(mouseState.X, mouseState.Y);

            previousMouseState = mouseState;
        }
        public void MouseClicked(int x, int y)
        {
            // Create a Rectangle around the mouse click position
            Rectangle mouseClickedRect = new Rectangle(x, y, 10, 10);

            Rectangle exitRect = new Rectangle((int)exitPosition.X, (int)exitPosition.Y, exitButton.Width, exitButton.Height);

            if (mouseClickedRect.Intersects(exitRect))
                Kernel._gameState = Kernel.GameStates.Exiting;
        }
        #endregion
    }
}
