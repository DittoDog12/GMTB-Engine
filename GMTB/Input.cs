using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{
    public class Input
    {
        #region Data Members
        public static string mDirection;
        public static bool mKeypress1;
        public float mSpeed;

        private Vector2 newVelocity;
        KeyboardState oldState;
        public event EventHandler<InputEvent> NewInput;
        #endregion

        #region Constructor
        public Input(float speed)
        {
            mKeypress1 = false;
            oldState = Keyboard.GetState();
            mSpeed = speed;
        }
        #endregion

        #region Methods
        protected virtual void OnNewInput(Vector2 Veloctiy, string Direction)
        {
            InputEvent args = new InputEvent(Veloctiy, Direction);
            NewInput(this, args);
        }
        public void AddListener(EventHandler<InputEvent> handler)
        {
            // Add event handler
            NewInput += handler;
        }

        public void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            //switch (newState.IsKeyDown(Keys))
            //{

            //}
            if (newState.IsKeyDown(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                newVelocity.Y = mSpeed * -1;
                mDirection = "Up";
            }
            else if (newState.IsKeyDown(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                newVelocity.X = mSpeed * -1;
                mDirection = "Left";
            }
            else if (newState.IsKeyDown(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                newVelocity.Y = mSpeed;
                mDirection = "Down";
            }
            else if (newState.IsKeyDown(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                newVelocity.X = mSpeed;
                mDirection = "Right";
            }
            else
            {
                newVelocity.X = 0;
                newVelocity.Y = 0;
                mDirection = "stop";
            }
            

            OnNewInput(newVelocity, mDirection);
            oldState = newState;
        }

        public static void GetInput(PlayerIndex playerIndex)
        {

            //---OLD INPUT SYSTEM---//
            //KeyboardState keyboardState = Keyboard.GetState();
            //// Player 1 Controls, will read WASD and Gamepad in Player One slot
            //if (playerIndex == PlayerIndex.One)
            //{
            //    if (mKeypress1 == false)
            //    {
            //        if (keyboardState.IsKeyDown(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            //        {
            //            mDirection = "Up";
            //            mKeypress1 = true;
            //        }
            //        else if (keyboardState.IsKeyDown(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            //        {
            //            mDirection = "Left";
            //            mKeypress1 = true;
            //        }
            //        else if (keyboardState.IsKeyDown(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            //        {
            //            mDirection = "Down";
            //            mKeypress1 = true;
            //        }
            //        else if (keyboardState.IsKeyDown(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            //        {
            //            mDirection = "Right";
            //            mKeypress1 = true;
            //        }
            //        else
            //        {
            //            mDirection = null;
            //        }
            //    }
            //    else
            //    {
            //        if (keyboardState.IsKeyUp(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released)
            //        {
            //            mDirection = "stop";
            //            mKeypress1 = false;
            //        }
            //        else if (keyboardState.IsKeyUp(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Released)
            //        {
            //            mDirection = "stop";
            //            mKeypress1 = false;
            //        }
            //        else if (keyboardState.IsKeyUp(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released)
            //        {
            //            mDirection = "stop";
            //            mKeypress1 = false;
            //        }
            //        else if (keyboardState.IsKeyUp(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Released)
            //        {
            //            mDirection = "stop";
            //            mKeypress1 = false;
            //        }
            //    }
            //}
     
            //return mDirection;
        }
        #endregion
    }
}
