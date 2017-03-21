using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace GMTB
{
    class LevelManager
    {
        #region Data Members
        private static LevelManager Instance = null;

        // Level Data
        private string LevelBG;
        private Vector2 DoorPos;
        private string targetLevel;
        private Vector2 PlayerPos;

        // XML Parser
        private string fileName;
        private XPathDocument doc;
        private XPathNavigator nav;
        #endregion

        #region Constructor
        private LevelManager()
        {
            fileName = Environment.CurrentDirectory + "/Content/Levels.xml";
            doc = new XPathDocument(fileName);
            nav = doc.CreateNavigator();
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
            // Load Background
            // Set search expression, Root + LevelID + Texture
            XPathExpression expr = nav.Compile("//" + LevelID + "/LevelTex");
            // Search using Expression
            XPathNodeIterator iterator = nav.Select(expr);
            while (iterator.MoveNext())
                LevelBG = iterator.Current.Value;
            // Load Door data
            // Load Door Position
            expr = nav.Compile("//" + LevelID + "//DoorX");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                DoorPos.X = float.Parse(iterator.Current.Value);
            expr = nav.Compile("//" + LevelID + "//DoorY");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                DoorPos.Y = float.Parse(iterator.Current.Value);
            // Load Player target position
            expr = nav.Compile("//" + LevelID + "//PlayerX");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                PlayerPos.X = float.Parse(iterator.Current.Value);
            expr = nav.Compile("//" + LevelID + "//PlayerY");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                PlayerPos.Y = float.Parse(iterator.Current.Value);
            // Load Target Level
            expr = nav.Compile("//" + LevelID + "//TargetLevel");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                targetLevel = iterator.Current.Value;


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
