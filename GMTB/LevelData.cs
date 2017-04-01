using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace GMTB
{
    [Serializable]
    public struct LevelData
    {
        #region Data Members
        public string bg;
        //public Vector2 playerStart;

        public List<Vector2> doorPos;
        public List<string> doorTarget;
        public List<Vector2> playerTarget;

        public List<Entity> entities;
        public List<Vector2> entityPos;
        #endregion
    }
}
