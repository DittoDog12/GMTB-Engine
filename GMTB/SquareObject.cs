﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    class SquareObject : Entity
    {
        #region Constructor
        public SquareObject(int pXpos, int pYpos) : base(pXpos, pYpos)
        {
            mTexturename = "square";
        }
        #endregion
    }
}