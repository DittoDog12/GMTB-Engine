using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    /// <summary>
    /// Contains global variables
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// Static Boolean to pause all activity while a dialouge box is running
        /// </summary>
        static bool _PauseInput;

        /// <summary>
        /// Static refernce to the Dialogue Box
        /// </summary>
        static IDialogue _DM;

        /// <summary>
        /// Accessor for _PauseInput
        /// </summary>
        public static bool PauseInput
        {
            get { return _PauseInput; }
            set { _PauseInput = value; }
        }

        /// <summary>
        /// Accessor for _DM
        /// </summary>
        public static IDialogue DM
        {
            get { return _DM; }
            set { _DM = value; }
        }
    }
}
