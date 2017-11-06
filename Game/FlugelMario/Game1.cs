using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using SuperMario.Game_Controllers;
using Microsoft.Xna.Framework.Input;
using FlugelMario;
using SuperMario.Sprites.Goomba;

namespace SuperMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : AbstractGame
    {
        private bool paused;

        List<GamepadControls> gamePads;
        KeyboardControls keyboard;
        SpriteBatch spriteBatch;
        MarioState marioState;
        private List<Sprite> sprites;
        Texture2D background;
        Rectangle mainFrame;
        public Camera camera;
        Vector2 parallax = new Vector2(1f);
        HUD hud;

        public bool Paused { get => paused; set => paused = value; }
        public List<Sprite> Sprites { get => sprites; set => sprites = value; }

        public Game1()
        {
            this.GraphicsManager = new GraphicsDeviceManager(this);
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
            gamePads = new List<GamepadControls>();

            Sprites = new List<Sprite>();

            Paused = false;

            camera = new Camera(GraphicsDevice.Viewport);
            camera.Limits= new Rectangle(0,0,1300,400);

            hud = new HUD();

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

            #endregion

            background = Content.Load<Texture2D>("background");
            mainFrame = new Rectangle(0, 0, 1800, GraphicsDevice.Viewport.Height);

            #region Instatntiation of Sprites

            marioState = LevelLoader.LoadLevel(Sprites);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(spriteBatch, sprite.Location);
            }

            marioState.StateSprite.Draw(spriteBatch, marioState.Location);

            spriteBatch.End();

            #endregion

            keyboard = new KeyboardControls(marioState, this);

            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                {
                    gamePads.Add(new GamepadControls(marioState, this, i));
                }
            }

            hud.LoadContent(Content);
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
            keyboard.Update();

            foreach (GamepadControls controller in gamePads)
            {
                controller.Update();
            }

            if (!Paused)
            {
                CheckCollision();

                marioState.Update(GraphicsDevice.Viewport, marioState.StateSprite.Location);

                foreach (Sprite sprite in Sprites)
                {
                    sprite.Update(GraphicsDevice.Viewport, marioState.StateSprite.Location);
                }
            }
            if ((MarioAttributes.MarioLife[0] != 0) && (marioState.MarioShape == Shape.Dead))
            {
                BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
                sprites.Clear();
                LoadContent();
            }
            camera.Update(camera, marioState.Location);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            #region SpriteBatch Drawing

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null, null, camera.GetViewMatrix(parallax));

            spriteBatch.Draw(background, mainFrame, Color.White);

            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(spriteBatch, sprite.Location);
            }

            marioState.StateSprite.Draw(spriteBatch, marioState.Location);

            hud.Draw(spriteBatch, marioState, camera, 1000);

            spriteBatch.End();

            #endregion
            base.Draw(gameTime);
        }

       
        #region Private

        private void CheckCollision()
        {
            for (int i = 0; i < Sprites.Count; i++)
            {
                if (HitsLeftSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Left);
                    Sprites[i].RespondToCollision(CollisionDirection.Left);
                } else if (HitsRightSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Right);
                    Sprites[i].RespondToCollision(CollisionDirection.Right);
                }
                else if (HitsTopSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Top);
                    Sprites[i].RespondToCollision(CollisionDirection.Top);
                }
                else if (HitsBottomSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Bottom);
                    Sprites[i].RespondToCollision(CollisionDirection.Bottom);
                }
            }
        }

        private static bool HitsLeftSide(Sprite sprite1, Sprite sprite2)
        {
            bool collidesLeftSide = false;
            if (sprite1.CollisionRectangle.Intersects(sprite2.CollisionRectangle))
            {
                Rectangle collisionRectangle = Rectangle.Intersect(sprite1.CollisionRectangle, sprite2.CollisionRectangle);
                collidesLeftSide = collisionRectangle.Height > collisionRectangle.Width && collisionRectangle.Left == sprite2.CollisionRectangle.Left;
            }
            return collidesLeftSide;
        }

        private static bool HitsRightSide(Sprite sprite1, Sprite sprite2)
        {
            bool collidesRightSide = false;
            if (sprite1.CollisionRectangle.Intersects(sprite2.CollisionRectangle))
            {
                Rectangle collisionRectangle = Rectangle.Intersect(sprite1.CollisionRectangle, sprite2.CollisionRectangle);
                collidesRightSide = collisionRectangle.Height > collisionRectangle.Width && collisionRectangle.Right == sprite2.CollisionRectangle.Right;
            }
            return collidesRightSide;
        }

        private static bool HitsTopSide(Sprite sprite1, Sprite sprite2)
        {
            bool collidesTopSide = false;
            if (sprite1.CollisionRectangle.Intersects(sprite2.CollisionRectangle))
            {
                Rectangle collisionRectangle = Rectangle.Intersect(sprite1.CollisionRectangle, sprite2.CollisionRectangle);
                collidesTopSide = collisionRectangle.Width > collisionRectangle.Height && collisionRectangle.Top == sprite2.CollisionRectangle.Top;
            }
            return collidesTopSide;
        }

        private static bool HitsBottomSide(Sprite sprite1, Sprite sprite2)
        {
            bool collidesBottomSide = false;
            if (sprite1.CollisionRectangle.Intersects(sprite2.CollisionRectangle))
            {
                Rectangle collisionRectangle = Rectangle.Intersect(sprite1.CollisionRectangle, sprite2.CollisionRectangle);
                collidesBottomSide = collisionRectangle.Width > collisionRectangle.Height && collisionRectangle.Bottom == sprite2.CollisionRectangle.Bottom;
            }
            return collidesBottomSide;
        }

        #endregion
    }
}
