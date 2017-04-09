﻿using Microsoft.Xna.Framework;

namespace GMTB
{
    class Door : Entity, Collidable
    {
        #region Data Members
        public string ToRoom;
        public Vector2 PlayerStart;
        #endregion

        #region Constructor
        public Door()
        {
            mTexturename = "BlueDoll";
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion

        #region Methods
        public override void setVars(string tRoom, Vector2 playerStart)
        {
            ToRoom = tRoom;
            PlayerStart = playerStart;
        }
        public override void Collision(object source, CollisionEvent args)
        {
            if (args.Entity == this)
            {
                // Trigger Room change
                LevelManager.getInstance.NewLevel(ToRoom);
                Global.PlayerPos = PlayerStart;
            }
        }
        public override void Destroy()
        {
            base.Destroy();
            CollisionManager.getInstance.unSubscribe(Collision, this);
        }
        public override void sub()
        {
            CollisionManager.getInstance.Subscribe(Collision, this);
        }
        #endregion
    }
}
