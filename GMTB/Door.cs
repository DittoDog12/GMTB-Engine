using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GMTB
{
    class Door : Entity, Collidable
    {
        #region Data Members
        private string ToRoom;
        private Vector2 PlayerStart;
        #endregion
        #region Constructor
        public Door()
        {
            mTexturename = "square";
        }
        #endregion
        #region Methods
        public override void setVars(string tRoom, Vector2 playerStart)
        {
            ToRoom = tRoom;
            PlayerStart = playerStart;
        }
        public override void Collision()
        {
            // Trigger Room change
            LevelManager.getInstance.NewLevel(ToRoom);
            RoomManager.getInstance.PlayerPos.Position = PlayerStart;
        }
        #endregion
    }
}
