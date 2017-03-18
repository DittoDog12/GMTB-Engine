using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace GMTB
{
    public class Script : IScript
    {
        #region Data Members
        string[] lines;
        IDialogue DM;
        int mLine;
        bool mNextLine;
        bool DialogueRunning;
        #endregion

        #region Constructor
        public Script()
        {
            mNextLine = false;
            DM = Kernel.DM;
            lines = File.ReadAllLines(Environment.CurrentDirectory + "/Content/Dialogue/FirstEncounter.txt");

            mLine = 0;
        }
        #endregion

        #region Methods
        public void RunDialogue()
        {
            DM.Display(lines[mLine]);
            while (DialogueRunning)
            {
                if (mNextLine)
                {
                    mNextLine = false;
                    mLine++;
                    DM.Display(lines[mLine]);
                }
                if (mLine == lines.Length)
                {
                    DialogueRunning = false;
                    Kernel.IM.UnSubscribeSpace(this.OnSpace);
                }
            }   
        }
        public void OnSpace(object source, InputEvent args)
        {
            mNextLine = true;
        }

        public void BeginDialogue(string[] Lines)
        {
            Kernel.IM.SubscribeSpace(this.OnSpace);
            lines = Lines;
            DialogueRunning = true;
            RunDialogue();
        }
        #endregion

}
}
