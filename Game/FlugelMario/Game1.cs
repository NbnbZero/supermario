using SuperMario.AbstractClasses;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using System.Collections;
using SuperMario.Game_Controllers;

namespace SuperMario
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

        public bool isPause=true;
        
        public ISprite Goomba { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Koopa")]
        public ISprite Koopa { get; set; }
        public static Shape MarioShape { get; set; }
        public BlockType BlockType { get; set; }
        
        Viewport viewport;
        IMarioState marioState;
        IBlockState QuestionBlockState;
        IBlockState BrickBlockState;
        public static InputState state;
        BlockChange QuestionBlockChange;
        BlockChange BrickBlockChange;
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
        public Vector2 starLocation;
        public Vector2 stairBlockLocation;
        public static List<Vector2> usedBlockLocations = new List<Vector2>();
        public static List<Vector2> questionBlockLocations = new List<Vector2>();
        public static List<Vector2> brickBlockLocations = new List<Vector2>();
        public static List<Vector2> hiddenBlockLocations = new List<Vector2>();
        public Vector2 usedBlockLocation1;
        public Vector2 questionBlockLocation1;
        public Vector2 hiddenBlock1;
        public static Vector2 brickBlockLocation1;
        public Vector2 rockBlockLocation;
        private ArrayList controllerList;

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
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController_GameControl(this));

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
            usedBlockLocation1 = new Vector2(7f * (viewport.Width / 10f), viewport.Height / 5f);
            questionBlockLocation1 = new Vector2(8f * (viewport.Width / 10f), viewport.Height / 5f);
            brickBlockLocation1 = new Vector2(9f * (viewport.Width / 10f), viewport.Height / 5f);
            rockBlockLocation = new Vector2(10f * (viewport.Width / 10f), viewport.Height / 5f);
            hiddenBlock1 = new Vector2(7f * (viewport.Width / 10f), viewport.Height / 2f);

            marioAction = new Action();

            QuestionBlockChange = new BlockChange();
            BrickBlockChange = new BlockChange();

            state = InputState.Nothing;
            MarioShape = Shape.Small;

            usedBlockLocations.Add(usedBlockLocation1);
            questionBlockLocations.Add(questionBlockLocation1);
            hiddenBlockLocations.Add(hiddenBlock1);
            brickBlockLocations.Add(brickBlockLocation1);

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
                    controllersWithStates.Add(new GamepadController(GamePad.GetState(i), marioState), InputState.Nothing);
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

            QuestionBlockState = new BlockState(BlockType.Question);
            BrickBlockState = new BlockState(BlockType.Brick);

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

            foreach (ICommandHandler controller in controllerList)
            {
                controller.Update();
            }
            if (isPause)
            {
                foreach (Controller controller in controllersWithStates.Keys)
                {

                    InputState newState = controller.Update(Keyboard.GetState());

                    if (newState != state)
                    {
                        marioAction.Execute(newState, marioState);

                        if (newState == InputState.ChangeToUsed)
                        {
                            QuestionBlockChange.Execute(newState, QuestionBlockState, questionBlockLocation1);
                        }
                        else if (newState == InputState.ChangeToVisible)
                        {
                            BrickBlockChange.Execute(newState, BrickBlockState, hiddenBlock1);
                        }
                        else if (newState == InputState.BumpUp)
                        {
                            BrickBlockChange.Execute(newState, BrickBlockState, brickBlockLocation1);
                        }
                        else if (newState == InputState.BreakBrick)
                        {
                            BrickBlockChange.Execute(newState, BrickBlockState, brickBlockLocation1);
                        }

                        state = newState;
                    }
                    else if (state == InputState.BumpUp)
                    {
                        BrickBlockChange.Execute(state, BrickBlockState, brickBlockLocation1);
                    }
                    else if (state == InputState.BreakBrick)
                    {
                        BrickBlock.Update();
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
            foreach (Vector2 location in usedBlockLocations)
            {
                UsedBlock.Draw(spriteBatch, location);
            }
            foreach (Vector2 location in questionBlockLocations)
            {
                QuestionBlock.Draw(spriteBatch, location);
            }
            if (state == InputState.ChangeToVisible)
            {
                foreach (Vector2 location in hiddenBlockLocations)
                {
                    BrickBlock.Draw(spriteBatch, location);
                }
            }
            BrickBlock.Draw(spriteBatch, brickBlockLocation1);

            RockBlock.Draw(spriteBatch, rockBlockLocation);

            base.Draw(gameTime);
        }
    }
}
