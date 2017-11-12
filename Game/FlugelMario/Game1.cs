using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using SuperMario.Game_Controllers;
using Microsoft.Xna.Framework.Input;
using SuperMario.GameObjects;
using SuperMario.Sprites.Goomba;
using SuperMario.Sound;
using SuperMairo.States.GameState;
using SuperMairo.SpriteFactories;

namespace SuperMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : AbstractGame
    {
        SpriteBatch spriteBatch;
        KeyboardControls keyboard;
        Camera camera1;
        Camera camera2;
        MarioObject Mario;
        GameObjectManager objectManager;
        public Game1()
        {
            this.GraphicsManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            State = new Title(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
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

            #region Load Textures
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            FireballSpriteFactory.Instance.LoadAllTextures(Content);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            PipeSpriteFactory.Instance.LoadAllTextures(Content);
            SoundManager.Instance.LoadAllSounds(Content);
            TextSpriteFactory.Instance.LoadAllTextures(Content);
            #endregion

            Vector2 location = new Vector2(50, 200);
            Mario = new MarioObject(location);

            objectManager = new GameObjectManager(this,Mario);

            camera1 = new Camera();
            camera2 = new Camera();

            LevelLoader loader = new LevelLoader(objectManager);
            loader.Load();

            keyboard = new KeyboardControls(this, Mario);

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
        /// 
        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();

            objectManager.Update();
            MarioAttributes.timeCount(gameTime,Mario);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera1.GetTransform* Matrix.CreateScale(GetScreenScale));
            objectManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Vector3 GetScreenScale
        {
            get
            {
                var scaleX = (float)GraphicsDevice.Viewport.Width / (float)760;
                var scaleY = (float)GraphicsDevice.Viewport.Height / (float)480;
                return new Vector3(scaleX, scaleY, 1.0f);
            }
        }

        public void Reset()
        {
            LoadContent();
            Camera.ResetCamera();
            MarioAttributes.ResetTimer();
            MarioAttributes.StartTimer();
        }
    }
}

