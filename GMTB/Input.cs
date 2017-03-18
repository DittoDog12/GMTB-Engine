﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{
    public class Input : IInput
    {
        #region Data Members
        KeyboardState oldState;
        public event EventHandler<InputEvent> NewInput;
        public event EventHandler<InputEvent> ExitInput;
        public event EventHandler<InputEvent> SpaceInput;
        #endregion

        #region Constructor
        public Input()
        {
            oldState = Keyboard.GetState();
        }
        #endregion

        #region Methods
        protected virtual void OnNewInput(Keys key)
        {
            InputEvent args = new InputEvent(key);
            NewInput(this, args);
        }
        protected virtual void OnSpaceInput(Keys key)
        {
            if (SpaceInput != null)
            {
                InputEvent args = new InputEvent(key);
                SpaceInput(this, args);
            }

        }


        public void SubscribeMove(EventHandler<InputEvent> handler)
        {
            // Add event handler
            NewInput += handler;
        }
        public void Unsubscribe(EventHandler<InputEvent> handler)
        {
            // Remove event handler
            //NewInput -= handler;
        }
        public void SubscribeExit(EventHandler<InputEvent> handler)
        {
            // Add event handler
            ExitInput += handler;
        }
        public void SubscribeSpace(EventHandler<InputEvent> handler)
        {
            SpaceInput += handler;
        }
        public void UnSubscribeSpace(EventHandler<InputEvent> handler)
        {
            SpaceInput -= handler;
        }

        public void Update()
        {
            if (!Global.PauseInput)
            {
                KeyboardState newState = Keyboard.GetState();

                if (newState.IsKeyDown(Keys.W) == true || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                {
                    OnNewInput(Keys.W);
                }
                else if (newState.IsKeyDown(Keys.A) == true || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    OnNewInput(Keys.A);
                }
                else if (newState.IsKeyDown(Keys.S) == true || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                {
                    OnNewInput(Keys.S);
                }
                else if (newState.IsKeyDown(Keys.D) == true || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                {
                    OnNewInput(Keys.D);
                }
                else if (newState.IsKeyDown(Keys.Space))
                {
                    OnSpaceInput(Keys.Space);
                }

                oldState = newState;
            }
        }
        #endregion
    }
}
