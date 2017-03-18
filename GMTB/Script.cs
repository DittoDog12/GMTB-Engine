using System;
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
        #region Data Members
        string[] lines;
        string Line;
        IDialogue DM;
        int mLine;
        bool mNextLine;
        bool DialogueRunning;
        bool newLine;
        float timer;
        float interval;
        GameTime gameTimer;
        bool SingleDialogueRun;
        #endregion

        #region Constructor
        public Script()
        {
            mNextLine = false;
            DM = Global.DM;
            lines = File.ReadAllLines(Environment.CurrentDirectory + "/Content/Dialogue/FirstEncounter.txt");

            mLine = 0;

            interval = 3000f;
            timer = 0f;

        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            gameTimer = gameTime;
            if (DialogueRunning)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                DM.Display(lines[mLine]);
                if (timer > interval) //(mNextLine) for Space control
                {
                    //mNextLine = false;
                    mLine++;
                    newLine = true;
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
            if (SingleDialogueRun)
            {
                timer += (float)gameTimer.ElapsedGameTime.TotalMilliseconds;
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
        public void OnSpace(object source, InputEvent args)
        {
            mNextLine = true;
        }

        public void BeginDialogue(string[] Lines)
        {
            //Kernel.IM.SubscribeSpace(OnSpace);
            lines = Lines;
            DialogueRunning = true;
            Global.PauseInput = true;
            newLine = true;
        }
        public void SingleDialogue(string line)
        {
            Line = line;
            SingleDialogueRun = true;
            Global.PauseInput = true;  
        }
        #endregion

}
}
