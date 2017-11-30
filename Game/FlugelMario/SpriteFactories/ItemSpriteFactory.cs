using SuperMario.Interfaces;
using SuperMario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Enums;
using SuperMario;

namespace SuperMario.SpriteFactories
{
    class ItemSpriteFactory
    {
        public static int ItemSpritesSheetRows { get; } = 5;
        public static int ItemSpriteSheetColumns { get; } = 4;
        
        public static int FlowerSpriteRow { get; } = 1;
        public static int FlowerSpriteColumn { get; } = 0;
        public static int FlowerSpriteTotalFrame { get; } = 0;
        public static int CoinSpriteRow { get; } = 4;
        public static int CoinSpriteColumn { get; } = 1;
        public static int CoinAnimeTotalFrame { get; } = 4;
        public static int SuperMushroomSpriteRow { get; } = 0;
        public static int SuperMushroomSpriteColumn { get; } = 1;
        public static int GreenMushroomSpriteRow { get; } = 0;
        public static int GreenMushromSpriteColumn { get; } = 0;
        public static int StarSpriteRow { get; } = 3;
        public static int StarSpriteColumn { get; } = 0;


        public static int FlagSpriteSheetColumns { get; } = 1;
        public static int FlagSpriteSheetRows { get; } = 3;
        public static int FlagSpriteSheetColumn { get; } = 0;
        public static int PiranhaPlantsColumn { get; } = 1;
        public static int FlagRow { get; } = 0;
        public static int FlagTopRow { get; } = 1;
        public static int FlagPoleRow { get; } = 2;
        public static int PiranhaPlantsRow { get; } = 2;





        public Texture2D itemSpriteSheet;
        public Texture2D CoinSpriteSheet;
        public Texture2D FlowerSpriteSheet;
        private Texture2D flagSpriteSheet;
        private Texture2D PiranhaPlantsSpriteSheet;
        private Texture2D peachSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("Itemsheet");
            CoinSpriteSheet = content.Load<Texture2D>("CoinSheet");
            FlowerSpriteSheet = content.Load<Texture2D>("FlowerSheet");
            flagSpriteSheet = content.Load<Texture2D>("flagpole");
            PiranhaPlantsSpriteSheet = content.Load<Texture2D>("Piranha Plants");
            peachSheet = content.Load<Texture2D>("peach");
        }

     

        public ISprite CreateFlowerSprite()
        {
            return new FlowerSprite(FlowerSpriteSheet);
        }

        public ISprite CreateCoinSprite()
        {
            return new CoinSprite(CoinSpriteSheet);
        }
        public ISprite CreateSuperMushroomSprite()
        {
            return new SuperMushroomSprite(itemSpriteSheet);
        }
        public ISprite CreateUpMushroomSprite()
        {
            return new UpMushroomSprite(itemSpriteSheet);
        }

        public ISprite CreateStarSprite()
        {
            return new StarSprite(itemSpriteSheet);
        }

        public ISprite CreateDisappearedSprite()
        {
            return new DisappearedSprite(itemSpriteSheet);
        }


        public ISprite CreateFlagPoleSprite()
        {
            return new FlagPoleSprite(flagSpriteSheet);
        }

        public ISprite CreateFlagTopSprite()
        {
            return new FlagTopSprite(flagSpriteSheet);
        }

        public ISprite CreateFlagSprite()
        {
            return new FlagSprite(flagSpriteSheet);
        }
        public ISprite CreatePiranhaPlantsSprite()
        {
            return new PiranhaPlantsSprite(PiranhaPlantsSpriteSheet);
        }
        public ISprite CreatePeachSprite()
        {
            return new PeachSprite(peachSheet);
        }
    }
}
