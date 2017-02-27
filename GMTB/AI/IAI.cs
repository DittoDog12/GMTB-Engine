using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB.AI
{
    public interface IAI
    {
        void Update();

        bool CollisionChecker();

        void Idle();
    }
}
