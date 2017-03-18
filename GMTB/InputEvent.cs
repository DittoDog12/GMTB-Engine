using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{
    /// <summary>
    /// Input event trigger
    /// </summary>
    public class InputEvent : EventArgs
    {
        public Keys currentKey;

        public InputEvent(Keys key)
        {
            currentKey = key;
        }
    }
}
