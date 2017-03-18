using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMTB.AI
{
    class FriendlyAI : AllAI
    {
        #region Data Members
        string[] lines;
        #endregion

        #region Constructor
        public FriendlyAI()
        {
            mCollidable = true;
            lines = File.ReadAllLines(Environment.CurrentDirectory + "/Content/Dialogue/OldManAndSerena.txt");
        }
        #endregion

        #region Methods
        public override void setVars(int uid)
        {
            UID = uid;
            mTexturename = "NPC/TaskGiverFront";
        }

        public override void Collision()
        {
           Kernel.ScM.BeginDialogue(lines);
        }
        #endregion
    }
}
