using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB
{
    class RoomManager
    {
        #region Data Members
        private static RoomManager Instance = null;
        private string mRoom;
        private Texture2D Background;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        private IPlayer mPlayerPos;
        #endregion

        #region Accessors
        public string Room
        {
            get { return mRoom; }
            set { mRoom = value; }
        }
        public IPlayer PlayerPos
        {
            get { return mPlayerPos; }
        }
        #endregion

        #region Constructor
        private RoomManager()
        {
            Content = Global.Content;
            mRoom = "Backgrounds/SpawnRoomBackground";
            for (int i = 0; i < EntityManager.getInstance.Entities.Count; i++)
            {
                var asInterface = EntityManager.getInstance.Entities[i] as IPlayer;
                if (asInterface != null)
                {
                    mPlayerPos = EntityManager.getInstance.Entities[i] as IPlayer;
                }
            }
        }
        public static RoomManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new RoomManager();
                return Instance;
            }
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            Background = Content.Load<Texture2D>(Room);
            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
        }
        #endregion
    }
}
