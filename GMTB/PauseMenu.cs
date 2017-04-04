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
    public class PauseMenu
    {
        #region Data Members
        Microsoft.Xna.Framework.Content.ContentManager Content;

        public bool isSubbed = false;

        private Texture2D startButton;
        private Vector2 startPosition;

        private Texture2D exitButton;
        private Vector2 exitPosition;

        private Texture2D resumeButton;
        private Vector2 resumePosition;

        MouseState mouseState;

        MouseState previousMouseState;
        #endregion

        #region Constructor
        public PauseMenu()
        {
            //Background = "Backgrounds/SpawnRoomBackground";
            Content = Global.Content;
            //RoomManager.getInstance.Room = Background;
        }
        #endregion

        #region Methods
        public void Initialize(SpriteBatch spriteBatch)
        {
            // create Start button, position a quarter the distance across the screen from the left, near the bottom
            startPosition = new Vector2(Kernel.ScreenWidth / 4, Kernel.ScreenHeight - 50);
            startButton = Content.Load<Texture2D>("start");

            // create Exit button, position a quarter the distance across the screen from the right, near the bottom
            exitPosition = new Vector2(Kernel.ScreenWidth - (Kernel.ScreenWidth / 4), Kernel.ScreenHeight - 50);
            exitButton = Content.Load<Texture2D>("Exit");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(startButton, startPosition, Color.White);
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

            Rectangle startRect = new Rectangle((int)startPosition.X, (int)startPosition.Y, startButton.Width, startButton.Height);
            Rectangle exitRect = new Rectangle((int)exitPosition.X, (int)exitPosition.Y, exitButton.Width, exitButton.Height);

            if (mouseClickedRect.Intersects(startRect))
            {
                Kernel._gameState = Kernel.GameStates.Loading;
            }
            else if (mouseClickedRect.Intersects(exitRect))
                Kernel._gameState = Kernel.GameStates.Exiting;
        }
        public void Sub()
        {
            Input.getInstance.SubscribeExit(onEsc);
            isSubbed = true;
        }
        public void unSub()
        {
            Input.getInstance.unSubscribeExit(onEsc);
            isSubbed = false;
        }
        public void onEsc(object source, EventArgs args)
        {
            Kernel._gameState = Kernel.GameStates.Loading;
        }
        #endregion
    }
}

