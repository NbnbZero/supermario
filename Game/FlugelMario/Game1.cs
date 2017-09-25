using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using FlugelMario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using FlugelMario.States.MarioStates;
using FlugelMario.Enums;

namespace FlugelMario
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<Controller, InputState> controllersWithStates; // Scalability ftw.

        public ISprite Goomba { get; set; }
        public ISprite Koopa { get; set; }
        public Shape marioShape { get; set; }

        Vector2 marioLocation;
        Vector2 goombaLocation;
        Vector2 koopaLocation;

        Viewport viewport;
        IMarioState marioState;
        InputState state;
        Action marioAction;
        public ISprite Flower { get; set; }
        public ISprite Coin { get; set; }
        public ISprite SuperMushroom { get; set; }
        public ISprite UpMushroom { get; set; }
        public ISprite Star { get; set; }
        public ISprite StairBlock { get; set; }
        public ISprite UsedBlock { get; set; }
        public ISprite QuestionBlock { get; set; }
        public ISprite BrickBlock { get; set; }
        public ISprite RockBlock { get; set; }

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
            controllersWithStates = new Dictionary<Controller, InputState>();

            viewport = graphics.GraphicsDevice.Viewport;
            marioLocation = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
            goombaLocation = new Vector2(viewport.Width / 4f, viewport.Height / 4f);
            koopaLocation = new Vector2(3f*(viewport.Width / 4f), viewport.Height / 4f);

            marioAction = new Action();
            state = InputState.Nothing;
            marioShape = Shape.Small;
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

            controllersWithStates.Add(new KeyboardController(Keyboard.GetState(), marioState), InputState.Nothing);

            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                    controllersWithStates.Add(new GamePadController(GamePad.GetState(i), marioState), InputState.Nothing);
            }

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Flower = ItemSpriteFactory.Instance.CreateFlowerSprite();
            Coin = ItemSpriteFactory.Instance.CreateCoinSprite();
            SuperMushroom = ItemSpriteFactory.Instance.CreateSuperMushroomSprite();
            UpMushroom = ItemSpriteFactory.Instance.CreateUpMushroomSprite();
            Star = ItemSpriteFactory.Instance.CreateStarSprite();

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            StairBlock = BlockSpriteFactory.Instance.CreateStairBlock();
            UsedBlock = BlockSpriteFactory.Instance.CreateUsedBlock();
            QuestionBlock = BlockSpriteFactory.Instance.CreateQuestionBlock();
            BrickBlock = BlockSpriteFactory.Instance.CreateBrickBlock();
            RockBlock = BlockSpriteFactory.Instance.CreateRockBlock();
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
            
            foreach(Controller controller in controllersWithStates.Keys)
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
            Flower.Update();
            Coin.Update();
            Star.Update();
            QuestionBlock.Update();
            // TODO: pass the InputState variable to the execute() method for a MarioAnimator.
            marioAction.Execute(state, marioState);
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

            Goomba.Draw(spriteBatch, new Vector2(100, 100));
            Koopa.Draw(spriteBatch, new Vector2(150, 100));

            Flower.Draw(spriteBatch,new Vector2(100,150));
            Coin.Draw(spriteBatch, new Vector2(150, 150));
            SuperMushroom.Draw(spriteBatch, new Vector2(200, 150));
            UpMushroom.Draw(spriteBatch, new Vector2(250, 150));
            Star.Draw(spriteBatch, new Vector2(300, 150));

            StairBlock.Draw(spriteBatch, new Vector2(100, 200));
            UsedBlock.Draw(spriteBatch, new Vector2(150, 200));
            QuestionBlock.Draw(spriteBatch, new Vector2(200, 200));
            BrickBlock.Draw(spriteBatch, new Vector2(250, 200));
            RockBlock.Draw(spriteBatch, new Vector2(300, 200));

            base.Draw(gameTime);
        }
    }
}
