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
            if (keyboardState.IsKeyDown(Keys.A) == true)
            {
                mDirection = "Left";
            }
            if (keyboardState.IsKeyDown(Keys.S) == true)
            {
                mDirection = "Down";
            }
            if (keyboardState.IsKeyDown(Keys.D) == true)
            {
                mDirection = "Right";
            }
            return mDirection;
        }
        #endregion
    }
}
