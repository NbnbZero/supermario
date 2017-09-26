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
        Texture2D background;

        public ISprite Goomba { get; set; }
        public ISprite Koopa { get; set; }
        public Shape marioShape { get; set; }
        public BlockType BlockType { get; set; }

        Viewport viewport;
        IMarioState marioState;
        IBlockState QuestionBlockState;        
        InputState state;
        BlockChange QuestionBlockChange;
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
            flowerLocation = new Vector2(1f * (viewport.Width / 10f), viewport.Height / 5f);
            coinLocation = new Vector2(2f * (viewport.Width / 10f), viewport.Height / 5f);
            superMushroomLocation = new Vector2(3f * (viewport.Width / 10f), viewport.Height / 5f);
            upMushroomLocation = new Vector2(4f * (viewport.Width / 10f), viewport.Height / 5f);
            starLocation = new Vector2(5f * (viewport.Width / 10f), viewport.Height / 5f);
            stairBlockLocation = new Vector2(6f * (viewport.Width / 10f), viewport.Height / 5f);
            usedBlockLocation = new Vector2(7f * (viewport.Width / 10f), viewport.Height / 5f);
            questionBlockLocation = new Vector2(8f * (viewport.Width / 10f), viewport.Height / 5f);
            brickBlockLocation = new Vector2(9f * (viewport.Width / 10f), viewport.Height / 5f);
            rockBlockLocation = new Vector2(10f * (viewport.Width / 10f), viewport.Height / 5f);

            marioAction = new Action();
            QuestionBlockChange = new BlockChange();
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
            QuestionBlockState = new BlockState(BlockType.Question);
            QuestionBlock = BlockSpriteFactory.Instance.CreateQuestionBlock();
            BrickBlock = BlockSpriteFactory.Instance.CreateBrickBlock();
            RockBlock = BlockSpriteFactory.Instance.CreateRockBlock();

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

            foreach(Controller controller in controllersWithStates.Keys)
            {
                InputState newState = controller.Update(Keyboard.GetState());

                if (newState != state)
                {
                    marioAction.Execute(newState, marioState);
                    QuestionBlockChange.Execute(newState, QuestionBlockState);
                    state = newState;
                }
                
                marioState.StateSprite.Update();
                QuestionBlockState.StateSprite.Update();
            }

            Goomba.Update();
            Koopa.Update();
            Flower.Update();
            Coin.Update();
            Star.Update();
            QuestionBlock.Update();

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

            base.Draw(gameTime);
        }
    }
}
