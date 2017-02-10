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
        public static bool mKeypress1;
        public static bool mKeypress2;
        #endregion

        #region Constructor
        public Input()
        {
            mKeypress1 = false;
            mKeypress2 = false;
        }
        #endregion

        #region Methods
        public static string GetInput(PlayerIndex playerIndex)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            // Player 1 Controls, will read WASD and Gamepad in Player One slot
            if (playerIndex == PlayerIndex.One)
            {
                if (mKeypress1 == false)
                {
                    if (keyboardState.IsKeyDown(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                    {
                        mDirection = "Up";
                        mKeypress1 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                    {
                        mDirection = "Left";
                        mKeypress1 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                    {
                        mDirection = "Down";
                        mKeypress1 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                    {
                        mDirection = "Right";
                        mKeypress1 = true;
                    }
                    else
                    {
                        mDirection = null;
                    }
                }
                else
                {
                    if (keyboardState.IsKeyUp(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress1 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress1 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress1 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress1 = false;
                    }

                }

            }
            // Player 2 Controls, will read Arrow Keys and Gamepad in Player Two slot
            if (playerIndex == PlayerIndex.Two)
            {

                if (mKeypress2 == false)
                {
                    if (keyboardState.IsKeyDown(Keys.Up) == true || GamePad.GetState(PlayerIndex.Two).DPad.Up == ButtonState.Pressed)
                    {
                        mDirection = "Up";
                        mKeypress2 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Left) == true || GamePad.GetState(PlayerIndex.Two).DPad.Left == ButtonState.Pressed)
                    {
                        mDirection = "Left";
                        mKeypress2 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Down) == true || GamePad.GetState(PlayerIndex.Two).DPad.Down == ButtonState.Pressed)
                    {
                        mDirection = "Down";
                        mKeypress2 = true;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Right) == true || GamePad.GetState(PlayerIndex.Two).DPad.Right == ButtonState.Pressed)
                    {
                        mDirection = "Right";
                        mKeypress2 = true;
                    }
                    else
                    {
                        mDirection = null;
                    }
                }
                else
                {
                    if (keyboardState.IsKeyUp(Keys.Up) == true || GamePad.GetState(PlayerIndex.Two).DPad.Up == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress2 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.Left) == true || GamePad.GetState(PlayerIndex.Two).DPad.Left == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress2 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.Down) == true || GamePad.GetState(PlayerIndex.Two).DPad.Down == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress2 = false;
                    }
                    else if (keyboardState.IsKeyUp(Keys.Right) == true || GamePad.GetState(PlayerIndex.Two).DPad.Right == ButtonState.Released)
                    {
                        mDirection = "stop";
                        mKeypress2 = false;
                    }

                }
            }

            return mDirection;
        }
        #endregion
    }
}
