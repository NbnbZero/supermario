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
using SuperMairo;

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
        Camera2D camera2;
        Vector2 parallax = new Vector2(0.1f);
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
            Camera.LimitationList.Add(3600);
            camera2 = new Camera2D(GraphicsDevice.Viewport);

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
            if (State.Type != SuperMairo.Interfaces.GameStates.Pause)
            { 
                objectManager.Update();
            }
            MarioAttributes.timeCount(gameTime,Mario);

            camera2.LookAt(new Vector2(Mario.Location.X - 20, GraphicsDevice.Viewport.Height / 2));          

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

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera2.GetViewMatrix(parallax));
            foreach (IGameObject obj in GameObjectManager.cloudList)
            {
                obj.Draw(spriteBatch);
            }
            spriteBatch.End();

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
                var scaleY = (float)GraphicsDevice.Viewport.Height / (float)800;
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

