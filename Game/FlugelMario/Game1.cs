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

namespace SuperMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : AbstractGame
    {
        SpriteBatch spriteBatch;
        KeyboardControls keyboard;
        Camera camera;
        MarioObject Mario;
        Vector2 mario_parallax = new Vector2(1f);
        GameObjectManager objectManager;

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
            #endregion

            Vector2 location = new Vector2(200, 200);
            Mario = new MarioObject(location);

            objectManager = new GameObjectManager(Mario);
            
            LevelLoader loader = new LevelLoader(objectManager);
            loader.Load();

            camera = new Camera(GraphicsDevice.Viewport);
            camera.Limits = new Rectangle(0, 0, 1300, 400);

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
        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();

            objectManager.Update();

            camera.Update(Mario);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(mario_parallax));
            objectManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

       
     /*   #region Private

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

        #endregion*/
    }
}

