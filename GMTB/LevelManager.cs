using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml;
using System.IO;

namespace GMTB
{
    class LevelManager
    {
        #region Data Members
        private static LevelManager Instance = null;

        // Level Data
        private string LevelID;
        private string LevelBG;
        private Vector2 DoorPos;
        private string targetLevel;
        private Vector2 PlayerPos;

        // XML Parser
        XmlTextReader XmlRdr;
        #endregion

        #region Constructor
        private LevelManager()
        {
            XmlRdr = new System.Xml.XmlTextReader("Levels");
        }
        public static LevelManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new LevelManager();
                return Instance;
            }
        }
        #endregion

        #region Methods

        public void NewLevel(string LevelID)
        {
            // Remove Entities

            // Parse XML
            while (XmlRdr.Read())
            {
                if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == LevelID)
                {
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "LevelTex")
                        LevelBG = XmlRdr.ReadElementContentAsString();
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "DoorX")
                        DoorPos.X = XmlRdr.ReadElementContentAsFloat();
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "DoorY")
                        DoorPos.Y = XmlRdr.ReadElementContentAsFloat();
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "PlayerX")
                        PlayerPos.X = XmlRdr.ReadElementContentAsFloat();
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "PlayerY")
                        PlayerPos.Y = XmlRdr.ReadElementContentAsFloat();
                    if (XmlRdr.NodeType == XmlNodeType.Element && XmlRdr.Name == "TargetLevel")
                        targetLevel = XmlRdr.ReadElementContentAsString();
                }
            }
            // New Level
            LoadBackground();
            PlaceDoor();
            
        }

        private void LoadBackground()
        {
            RoomManager.getInstance.Room = LevelBG;
        }
        private void PlaceDoor()
        {
            IEntity createdEntity = EntityManager.getInstance.newEntity<Door>();
            SceneManager.getInstance.newEntity(createdEntity, (int)DoorPos.X, (int)DoorPos.Y);
            createdEntity.setVars(targetLevel, new Vector2(PlayerPos.X, PlayerPos.Y));
        }
        #endregion
    }
}
