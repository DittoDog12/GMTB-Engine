﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public class Script : IScript
    {
        /// <summary>
        /// Dialogue Script control, sends the Dialogue Box the individual lines and controls the line display delay
        /// </summary>
        #region Data Members
        string[] lines; // List holding the current conversation
        string Line; // String to hold a single line of dialogue
        IDialogue DM; // Reference to the Dialogue Box
        int mLine; // Currently displayed line
        bool mNextLine; // Used for spacebar control of text if implemented
        bool DialogueRunning; // Internal boolean to control if a conversation is running
        bool SingleDialogueRun; // Internal boolean to control a single line of dialogue

        // Line by line delay controls
        float timer;
        float interval;

        #endregion

        #region Constructor
        public Script()
        {
            //mNextLine = false; // Used for spacebar control of text if implemented
            DM = Global.DM; // Initialise reference to the Dialogue Box
            lines = File.ReadAllLines(Environment.CurrentDirectory + "/Content/Dialogue/FirstEncounter.txt"); // Initial conversation loaded to list

            mLine = 0;

            // Set Line by line delay to 3 seconds.
            interval = 3000f;
            timer = 0f;
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            // Display an entire conversaion
            if (DialogueRunning)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                DM.Display(lines[mLine]); // Display current line of loaded list
                // Load next line at interval
                if (timer > interval) //(mNextLine) for Space control 
                {
                    //mNextLine = false;
                    mLine++; // increment current line
                    timer = 0f;
                }
                if (mLine == lines.Length)
                {
                    DM.Display(" ");
                    DialogueRunning = false;
                    Global.PauseInput = false;
                    //Kernel.IM.UnSubscribeSpace(this.OnSpace);
                }
            }
            // Display a single line of dialogue   
            if (SingleDialogueRun)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                // Kernel.IM.SubscribeSpace(OnSpace);
                DM.Display(Line);
                if (timer > interval)
                {
                    DM.Display(" ");
                    Global.PauseInput = false;
                    SingleDialogueRun = false;
                }
            }

        }
        // Used to move the dialogue forwards on pressing the space bar, currenly skips several lines
        public void OnSpace(object source, InputEvent args)
        {
            mNextLine = true;
        }

        // Called by Collision triggers to start a conversaion
        public void BeginDialogue(string[] Lines)
        {
            //Kernel.IM.SubscribeSpace(OnSpace);
            lines = Lines;
            DialogueRunning = true;
            Global.PauseInput = true;
        }

        // Called by Collision triggers to display one line of dialogue
        public void SingleDialogue(string line)
        {
            Line = line;
            SingleDialogueRun = true;
            Global.PauseInput = true;  
        }
        #endregion

}
}
