﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.Xml.Serialization;

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
        public void newEntity(IEntity createdEntity, int x, int y)
        {
            // Add the new entity to the SceneManagers entity list
            //mEntities.Add(createdEntity);

            mSceneGraph.Add(createdEntity);
            // Apply the entities texture
            mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
            // Set the entities initial position
            createdEntity.setPos(x, y);

        }
        public void Update(GameTime gameTime)
        {
            //if(runonce)
            //{
            //    var xmlSettings = new XmlWriterSettings
            //    {
            //        Indent = true,
            //        IndentChars = "\t",
            //        NewLineChars = "\n"
            //    };

            //    var destinationFileName = "L1";
            //    using (var outputfile = XmlWriter.Create(destinationFileName, xmlSettings))
            //    {
            //        IntermediateSerializer
            //    }
            //        runonce = false;
            //}
            mEntities.ForEach(IEntity => IEntity.Update(gameTime));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            RoomManager.getInstance.Draw(spriteBatch);

            if (!Global.GameOver)
            {
                // Update Texture path for animating entity
                mEntities.ForEach(IEntity => IEntity.aTexture = Content.Load<Texture2D>(IEntity.aTexturename));
                // Call draw method for each Entity
                //mEntities.ForEach(IEntity => IEntity.Draw(spriteBatch));
                for (int i = 0; i < mEntities.Count; i++)
                    if (mEntities[i].Visible)
                        mEntities[i].Draw(spriteBatch);
                if (Global.PauseInput)
                    DialogueBox.getInstance.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
        #endregion
    }
}
