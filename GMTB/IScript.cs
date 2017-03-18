using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface IScript
    {
        void BeginDialogue(string[] Lines);
        void SingleDialogue(string line);
        void Update(GameTime gameTime);
    }
}
