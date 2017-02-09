using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{
    class Input
    {
        #region Data Members
        public static string mDirection;
        #endregion

        #region Constructor
        public Input()
        {

        }
        #endregion

        #region Methods
        public static string GetInput(PlayerIndex playerIndex)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            // Player 1 Controls, will read WASD and Gamepad in Player One slot
            if (playerIndex == PlayerIndex.One)
            {
                if (keyboardState.IsKeyDown(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                {
                    mDirection = "Up";
                }
                else if (keyboardState.IsKeyDown(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    mDirection = "Left";
                }
                else if (keyboardState.IsKeyDown(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                {
                    mDirection = "Down";
                }
                else if (keyboardState.IsKeyDown(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right== ButtonState.Pressed)
                {
                    mDirection = "Right";
                }
                else
                {
                    mDirection = null;
                }
            }
            // Player 2 Controls, will read Arrow Keys and Gamepad in Player Two slot
            if (playerIndex == PlayerIndex.Two)
            {

                if (keyboardState.IsKeyDown(Keys.Up) == true || GamePad.GetState(PlayerIndex.Two).DPad.Up == ButtonState.Pressed)
                {
                    mDirection = "Up";
                }
                else if (keyboardState.IsKeyDown(Keys.Left) == true || GamePad.GetState(PlayerIndex.Two).DPad.Left == ButtonState.Pressed)
                {
                    mDirection = "Left";
                }
                else if (keyboardState.IsKeyDown(Keys.Down) == true || GamePad.GetState(PlayerIndex.Two).DPad.Down == ButtonState.Pressed)
                {
                    mDirection = "Down";
                }
                else if (keyboardState.IsKeyDown(Keys.Right) == true || GamePad.GetState(PlayerIndex.Two).DPad.Right == ButtonState.Pressed)
                {
                    mDirection = "Right";
                }
                else
                {
                    mDirection = null;
                }
            }

            return mDirection;
        }
        #endregion
    }
}
