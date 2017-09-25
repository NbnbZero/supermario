using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using FlugelMario.States.MarioStates;

namespace FlugelMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<IController, InputState> controllersWithStates; // Scalability ftw.

        public ISprite Goomba { get; set; }
        public ISprite Koopa { get; set; }

        Vector2 marioLocation;
        Vector2 goombaLocation;
        Vector2 koopaLocation;

        Viewport viewport;
        IMarioState marioState;
        InputState state;
        Action marioAction;

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
            #region Controller Initializers

            controllersWithStates = new Dictionary<IController, InputState>();

            controllersWithStates.Add(new KeyboardController(Keyboard.GetState()), InputState.Nothing);

            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                    controllersWithStates.Add(new GamePadController(GamePad.GetState(i)), InputState.Nothing);
            }

            #endregion

            viewport = graphics.GraphicsDevice.Viewport;
            marioLocation = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            goombaLocation = new Vector2(viewport.Width / 4f, viewport.Height / 4f);
            koopaLocation = new Vector2(3f*(viewport.Width / 4f), viewport.Height / 4f);

            marioAction = new Action();
            state = InputState.Nothing;

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
            MarioSpriteFactory.Instance.LoadAllTextures(Content);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            Goomba = EnemySpriteFactory.Instance.CreateGoombaSprite();
            Koopa = EnemySpriteFactory.Instance.CreateKoopaSprite();

            marioState = new MarioState();
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

            #region Controllers Update
            
            foreach(IController controller in controllersWithStates.Keys)
            {
                InputState newState = controller.Update(Keyboard.GetState());

                if (newState != state)
                {
                    marioAction.Execute(newState, marioState);
                    state = newState;
                }

                marioState.StateSprite.Update();
            }

            #endregion

            Goomba.Update();
            Koopa.Update();
            // TODO: pass the InputState variable to the execute() method for a MarioAnimator.
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Goomba.Draw(spriteBatch, goombaLocation);
            Koopa.Draw(spriteBatch, koopaLocation);

            marioState.StateSprite.Draw(spriteBatch, marioLocation);

            base.Draw(gameTime);
        }
    }
}
