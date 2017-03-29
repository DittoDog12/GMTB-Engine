using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
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
            for (int i = 0; i < SceneManager.getInstance.SceneGraph.Count; i++)
                if (SceneManager.getInstance.SceneGraph[i] != null)
                    if (SceneManager.getInstance.SceneGraph[i].UName != "Player")
                        EntityManager.getInstance.removeEntity(SceneManager.getInstance.SceneGraph[i].UID);


            // Parse XML
            fileName = Environment.CurrentDirectory + "/Content/Levels/" + LevelID + ".xml";
            doc = new XPathDocument(fileName);
            nav = doc.CreateNavigator();
            // Load Background
            // Set search expression, Root + LevelID + Texture
            XPathExpression expr = nav.Compile("//LevelTex");
            // Search using Expression
            XPathNodeIterator iterator = nav.Select(expr);
            while (iterator.MoveNext())
                LevelBG = iterator.Current.Value;
            // Load Door data
            // Load Door Position
            expr = nav.Compile("//DoorX");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                DoorPos.X = float.Parse(iterator.Current.Value);
            expr = nav.Compile("//DoorY");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                DoorPos.Y = float.Parse(iterator.Current.Value);
            // Load Player target position
            expr = nav.Compile("//PlayerX");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                PlayerPos.X = float.Parse(iterator.Current.Value);
            expr = nav.Compile("//PlayerY");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                PlayerPos.Y = float.Parse(iterator.Current.Value);
            // Load Target Level
            expr = nav.Compile("//TargetLevel");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
                targetLevel = iterator.Current.Value;

            //// Load Entites
            //expr = nav.Compile("//Entity");
            //iterator = nav.Select(expr);
            //while (iterator.MoveNext())
            //{
            //    IEntity createdEntity = EntityManager.getInstance.newEntity<>();
            //    SceneManager.getInstance.newEntity(createdEntity, new Vector2());
            //}


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
