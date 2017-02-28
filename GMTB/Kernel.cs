using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GMTB
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;

        // Create Entity, Scene and Collision managers
        public IEntityManager EM;
        public ISceneManager SM;
        public ICollisionManager CM;
        public IAiManager AiM;
        // Create empty IEntity object to hold entities during creation
        private IEntity createdEntity;

        // Create SpriteFont
        private SpriteFont mFont;

        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            // Initialize Entity and Scene Managers
            EM = new EntityManager();
            SM = new SceneManager(Content);
            CM = new CollisionManager(SM.Entities);
            AiM = new AiManager();

            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mFont = Content.Load<SpriteFont>("HudText");
            
            createdEntity = EM.newEntity<Player>(PlayerIndex.One);
            SM.newEntity(createdEntity, 0, ScreenHeight / 2);
            createdEntity = EM.newEntity<Player>(PlayerIndex.Two);
            SM.newEntity(createdEntity, ScreenWidth - 28, ScreenHeight / 2);
            createdEntity = EM.newEntity<Pong.Ball>();
            SM.newEntity(createdEntity, ScreenWidth / 2, ScreenHeight / 2);
            CM.IdentifyPlayers();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            SM.Update(gameTime);
            CM.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SM.Draw(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.DrawString(mFont, "test", new Vector2(ScreenHeight / 2, ScreenWidth / 2), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}
