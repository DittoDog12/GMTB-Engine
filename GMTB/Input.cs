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
        public static string GetKeyboardInputDirection(PlayerIndex playerIndex)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W) == true)
            {
                mDirection = "Up";
            }
            else if (keyboardState.IsKeyDown(Keys.A) == true)
            {
                mDirection = "Left";
            }
            else if (keyboardState.IsKeyDown(Keys.S) == true)
            {
                mDirection = "Down";
            }
            else if (keyboardState.IsKeyDown(Keys.D) == true)
            {
                mDirection = "Right";
            }
            else
            {
                mDirection = null;
            }

            return mDirection;
        }
        #endregion
    }
}
