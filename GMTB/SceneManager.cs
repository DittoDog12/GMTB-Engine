using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using GMTB.AI;

namespace GMTB
{
    public class SceneManager
    {
        /// <summary>
        /// Main Scene Manager, places everything on the screen and calls Draw methods
        /// </summary>
        #region Data Members
        private static SceneManager Instance = null;

        private List<IEntity> mEntities;
        private List<IEntity> mSceneGraph;
        Microsoft.Xna.Framework.Content.ContentManager Content;

        private bool runonce = true;
        #endregion

        #region Accessors
        public List<IEntity> Entities
        {
            get { return mEntities; }
        }

        public List<IEntity> SceneGraph
        {
            get { return mSceneGraph; }
        }
        #endregion

        #region Constructor
        private SceneManager()
        {
            // Initialise Entity List
            mEntities = EntityManager.getInstance.Entities;
            mSceneGraph = new List<IEntity>();
            Content = Global.Content;
        }
        public static SceneManager getInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new SceneManager();
                return Instance;
            }
        }
        #endregion

        #region Methods
        public void Serialize()
        {
            if (runonce)
            {
                LevelData data = new LevelData();
                data.doorPos = new List<Vector2>();
                data.doorTarget = new List<string>();
                data.playerTarget = new List<Vector2>();
                data.entities = new List<Entity>();
                data.entityPos = new List<Vector2>();
                data.bg = RoomManager.getInstance.Room;
                foreach (IEntity e in mEntities)
                {
                    if (e.UName != "Player")
                    {
                        var entity = e as Door;
                        if (entity != null)
                        {
                            data.doorPos.Add(entity.Position);
                            data.doorTarget.Add(entity.ToRoom);
                            data.playerTarget.Add(entity.PlayerStart);
                        }
                        else
                        {
                            var currentEntity = e as Entity;
                            data.entities.Add(currentEntity);
                            data.entityPos.Add(currentEntity.Position);
                        }
                    }

                }

                var xmlSettings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = "\n"
                };

                string filename = Environment.CurrentDirectory + "\\Content\\Levels\\" + "L1.lvl";
                FileStream stream = File.Open(filename, FileMode.OpenOrCreate);

                XmlSerializer serializer = new XmlSerializer(typeof(LevelData));
                serializer.Serialize(stream, data);
                stream.Close();
                runonce = false;
            }
        }

        public void newEntity(IEntity createdEntity, int x, int y)
        {
            // Add the new entity to the SceneManagers entity list
            //mEntities.Add(createdEntity);

            mSceneGraph.Add(createdEntity);
            // Apply the entities texture
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            // Set the entities initial position
            createdEntity.setPos(x, y);
            createdEntity.DefaultPos = new Vector2(x, y);

        }
        public void Update(GameTime gameTime)
        {
            if (Kernel._gameState == Kernel.GameStates.Playing)
                mEntities.ForEach(IEntity => IEntity.Update(gameTime));
            if (Kernel._gameState == Kernel.GameStates.Paused)
                Kernel.menu2.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            RoomManager.getInstance.Draw(spriteBatch);

            if (Kernel._gameState != Kernel.GameStates.GameOver)
            {
                // Update Texture path for animating entity
                mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
                // Call draw method for each Entity
                //mEntities.ForEach(IEntity => IEntity.Draw(spriteBatch));
                for (int i = 0; i < mEntities.Count; i++)
                    if (mEntities[i].Visible)
                        mEntities[i].Draw(spriteBatch);
                if (Kernel._gameState == Kernel.GameStates.Dialogue)
                    DialogueBox.getInstance.Draw(spriteBatch);
                if (Kernel._gameState == Kernel.GameStates.Paused)
                    if (Kernel.menu2 != null)
                        Kernel.menu2.Draw(spriteBatch);

            }

            spriteBatch.End();
        }
        #endregion
    }
}
