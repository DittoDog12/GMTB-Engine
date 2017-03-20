﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMTB.AI
{
    /// <summary>
    /// Friendly AI controller, will trigger a conversation on first collision
    /// and a single line of dialogue on subsequent collisions
    /// </summary>
    class FriendlyAI : Entity
    {
        #region Data Members
        private string[] lines;
        private bool SecondEncounter;
        private string RepeatedText;
        #endregion

        #region Constructor
        public FriendlyAI()
        {
            SecondEncounter = false;
            RepeatedText = "*The Old Man doesn't turn around*";
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
            if (!SecondEncounter)
            {
                Script.getInstance.BeginDialogue(lines);
                SecondEncounter = true;
            }
            else
                Script.getInstance.SingleDialogue(RepeatedText);
        }
        #endregion
    }
}
