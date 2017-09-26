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

        #region Sprite Declarations

        public ISprite Goomba { get; set; }
        public ISprite Koopa { get; set; }
        public Shape marioShape { get; set; }
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

        #endregion

        #region Location Declarations

        Vector2 marioLocation;
        Vector2 goombaLocation;
        Vector2 koopaLocation;
        Vector2 flowerLocation;
        Vector2 coinLocation;
        Vector2 superMushroomLocation;
        Vector2 upMushroomLocation;
        Vector2 starLocation;
        Vector2 stairBlockLocation;
        Vector2 usedBlockLocation;
        Vector2 questionBlockLocation;
        Vector2 brickBlockLocation;
        Vector2 rockBlockLocation;

        #endregion

        #region Miscelaneous Declarations

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<Controller, Input> controllersWithStates;
        Texture2D background;
        Viewport viewport;
        IMarioState marioState;
        Input state;
        MarioCommand marioAction;

        #endregion


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
            controllersWithStates = new Dictionary<Controller, Input>();

            viewport = graphics.GraphicsDevice.Viewport;

            marioAction = new MarioCommand();

            // Start Mario off as small doing nothing.
            state = Input.Nothing;
            marioShape = Shape.Small;

            #region Sprite Location Definitions

            // Put Mario in the middle just because.
            var middleHeight = viewport.Height / 2f;
            var middleWidth = viewport.Width / 2f;

            marioLocation = new Vector2(middleWidth, middleHeight);

            // Put all the other sprites somwehere random
            var row1 = viewport.Height / 5f;
            var row2 = viewport.Height / 4f;
            var columndWidth = viewport.Width / 10f;

            goombaLocation = new Vector2(viewport.Width / 4f, row2);
            koopaLocation = new Vector2(3f*(viewport.Width / 4f), row2);
            flowerLocation = new Vector2(1f * columndWidth, row1);
            coinLocation = new Vector2(2f * columndWidth, row1);
            superMushroomLocation = new Vector2(3f * columndWidth, row1);
            upMushroomLocation = new Vector2(4f * columndWidth, row1);
            starLocation = new Vector2(5f * columndWidth, row1);
            stairBlockLocation = new Vector2(6f * columndWidth, row1);
            usedBlockLocation = new Vector2(7f * columndWidth, row1);
            questionBlockLocation = new Vector2(8f * columndWidth, row1);
            brickBlockLocation = new Vector2(9f * columndWidth, row1);
            rockBlockLocation = new Vector2(10f * columndWidth, row1);

            #endregion

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

            #region Controller Initialization Logic

            MarioSpriteFactory.Instance.LoadAllTextures(Content);

            marioState = new MarioState();

            controllersWithStates.Add(new KeyboardController(Keyboard.GetState(), marioState), Input.Nothing);

            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                if (GamePad.GetState(i).IsConnected)
                    controllersWithStates.Add(new GamePadController(GamePad.GetState(i), marioState), Input.Nothing);
            }

            #endregion

            #region Sprite Defitions

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            Goomba = EnemySpriteFactory.Instance.CreateGoombaSprite();
            Koopa = EnemySpriteFactory.Instance.CreateKoopaSprite();

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Flower =        ItemSpriteFactory.Instance.CreateFlowerSprite();
            Coin =          ItemSpriteFactory.Instance.CreateCoinSprite();
            SuperMushroom = ItemSpriteFactory.Instance.CreateSuperMushroomSprite();
            UpMushroom =    ItemSpriteFactory.Instance.CreateUpMushroomSprite();
            Star =          ItemSpriteFactory.Instance.CreateStarSprite();

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            StairBlock =    BlockSpriteFactory.Instance.CreateStairBlock();
            UsedBlock =     BlockSpriteFactory.Instance.CreateUsedBlock();
            QuestionBlock = BlockSpriteFactory.Instance.CreateQuestionBlock();
            BrickBlock =    BlockSpriteFactory.Instance.CreateBrickBlock();
            RockBlock =     BlockSpriteFactory.Instance.CreateRockBlock();

            #endregion

            background = Content.Load<Texture2D>("Background");
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

            #region Mario Update

            foreach(Controller controller in controllersWithStates.Keys)
            {
                Input newState = controller.Update(Keyboard.GetState());

                if (newState != state)
                {
                    marioAction.Execute(newState, marioState);
                    state = newState;
                }
                
                marioState.StateSprite.Update();
            }

            #endregion

            #region Other Sprite Updates

            Goomba.Update();
            Koopa.Update();
            Flower.Update();
            Coin.Update();
            Star.Update();
            QuestionBlock.Update();

            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();

            #region Sprite Draws

            marioState.StateSprite.Draw(spriteBatch, marioLocation);
            Goomba.Draw(spriteBatch, goombaLocation);
            Koopa.Draw(spriteBatch, koopaLocation);
            Flower.Draw(spriteBatch, flowerLocation);
            Coin.Draw(spriteBatch, coinLocation);
            SuperMushroom.Draw(spriteBatch, superMushroomLocation);
            UpMushroom.Draw(spriteBatch, upMushroomLocation);
            Star.Draw(spriteBatch, starLocation);
            StairBlock.Draw(spriteBatch, stairBlockLocation);
            UsedBlock.Draw(spriteBatch, usedBlockLocation);
            QuestionBlock.Draw(spriteBatch, questionBlockLocation);
            BrickBlock.Draw(spriteBatch, brickBlockLocation);
            RockBlock.Draw(spriteBatch, rockBlockLocation);

            #endregion

            base.Draw(gameTime);
        }
    }
}
