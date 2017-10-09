using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using SuperMario.Game_Controllers;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace SuperMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private bool paused;

        List<GamepadControls> gamePads;
        KeyboardControls keyboard;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MarioState marioState;
        private List<Sprite> sprites;

        public bool Paused { get => paused; set => paused = value; }
        public List<Sprite> Sprites { get => sprites; set => sprites = value; }

        public Game1()
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
            gamePads = new List<GamepadControls>();

            Sprites = new List<Sprite>();

            Paused = false;

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

                marioState.Update();

                foreach (Sprite sprite in Sprites)
                {
                    sprite.Update();
                }
            }

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

            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(spriteBatch, sprite.Location);
            }

            marioState.StateSprite.Draw(spriteBatch, marioState.Location);

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
                } else if (HitsRightSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Right);
                }
                else if (HitsTopSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Top);
                }
                else if (HitsBottomSide(marioState.StateSprite, Sprites[i]))
                {
                    Sprites[i] = marioState.RespondToCollision(Sprites[i], CollisionDirection.Right);
                }
            }
        }

        private static bool HitsLeftSide(Sprite sprite1, Sprite sprite2)
        {
            var collidesLeftSide = (sprite1.CollisionRectangle.Right >= sprite2.CollisionRectangle.Left) && sprite1.CollisionRectangle.Right <= sprite2.CollisionRectangle.Left + sprite2.Width;
            return OnSameLevel(sprite1, sprite2) && !HitsTopSide(sprite1, sprite2) && !HitsBottomSide(sprite1, sprite2) && collidesLeftSide;
        }

        private static bool HitsRightSide(Sprite sprite1, Sprite sprite2)
        {
            var collidesRightSide = (sprite1.CollisionRectangle.Left <= sprite2.CollisionRectangle.Right) && sprite1.CollisionRectangle.Left >= sprite2.CollisionRectangle.Right - sprite2.Width;
            return OnSameLevel(sprite1, sprite2) && !HitsTopSide(sprite1, sprite2) && !HitsBottomSide(sprite1, sprite2) && collidesRightSide;
        }

        private static bool OnSameLevel(Sprite sprite1, Sprite sprite2)
        {
            var topWithinBounds = (sprite1.Location.Y >= sprite2.Location.Y && sprite1.Location.Y <= sprite2.Location.Y + sprite2.Height);
            var bottomWithinBounds = (sprite1.Location.Y + sprite1.Height >= sprite2.Location.Y && sprite1.Location.Y + sprite1.Height <= sprite2.Location.Y + sprite2.Height);
            var withinTopAndBottom = (sprite2.CollisionRectangle.Top >= sprite1.CollisionRectangle.Top) && (sprite2.CollisionRectangle.Top <= sprite1.CollisionRectangle.Bottom);
            return topWithinBounds || bottomWithinBounds || withinTopAndBottom;
        }

        private static bool HitsTopSide(Sprite sprite1, Sprite sprite2)
        {
            var collidesTopSide = ((sprite1.CollisionRectangle.Bottom >= sprite2.CollisionRectangle.Top) && (sprite1.CollisionRectangle.Bottom <= sprite2.CollisionRectangle.Bottom));
            return InSameColumn(sprite1, sprite2) && collidesTopSide;
        }

        private static bool HitsBottomSide(Sprite sprite1, Sprite sprite2)
        {
            var collidesBottomSide = ((sprite1.CollisionRectangle.Top >= sprite2.CollisionRectangle.Bottom) && (sprite1.CollisionRectangle.Top <= sprite2.CollisionRectangle.Bottom));
            return InSameColumn(sprite1, sprite2) && collidesBottomSide;
        }

        private static bool InSameColumn(Sprite sprite1, Sprite sprite2)
        {
            var leftSideInBounds = (sprite1.CollisionRectangle.Left >= sprite2.CollisionRectangle.Right && sprite1.CollisionRectangle.Left <= sprite2.CollisionRectangle.Right);
            var rightSideInBounds = (sprite1.CollisionRectangle.Right <= sprite2.CollisionRectangle.Right && sprite1.CollisionRectangle.Right >= sprite2.CollisionRectangle.Left);
            var withinLeftandRight = (sprite1.CollisionRectangle.Left <= sprite2.CollisionRectangle.Left) && (sprite1.CollisionRectangle.Right >= sprite2.CollisionRectangle.Right);
            return leftSideInBounds || rightSideInBounds || withinLeftandRight;
        }

        #endregion
    }
}
