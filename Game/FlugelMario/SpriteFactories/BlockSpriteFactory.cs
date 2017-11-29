using SuperMario.Interfaces;
using SuperMario.Sprites.Blocks;
using SuperMario.Sprites.Items;
using SuperMario.Sprites.StairBlocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Sprites.Block;

namespace SuperMario.SpriteFactories
{
    class BlockSpriteFactory
    {
        public int StairSpriteSheetColum { get; } = 1;
        public int StairSpriteSheetRows { get; } = 1;

        public int UsedSpriteSheetColum { get; } = 1;
        public int UsedSpriteSheetRows { get; } = 1;
        public int UsedBlockAnimeTotalFrame { get; } = 1;

        public int QuestionSpriteSheetColum { get; } = 3;
        public int QuestionSpriteSheetRows { get; } = 1;
        public int QuestionBlockAnimeTotalFrame { get; } = 3;

        public int BrickSpriteSheetColum { get; } = 3;
        public int BrickSpriteSheetRows { get; } = 1;
        public int BrickBlockAnimeTotalFrame { get; } = 3;

        public int RockSpriteSheetColum { get; } = 1;
        public int RockSpriteSheetRows { get; } = 1;
        public int RockBlockAnimeTotalFrame { get; } = 1;

        public int UnderwaterBlockSpriteColumns { get; } = 1;
        public int UnderwaterBlockSpriteRows { get; } = 1;

        public int SeaWeedSpriteColumns { get; } = 1;
        public int SeaweedSpriteRows { get; } = 1;



        private Texture2D StairSpriteSheet;
        private Texture2D UsedSpriteSheet;
        private Texture2D QuestionSpriteSheet;
        private Texture2D BrickSpriteSheet;
        private Texture2D RockSpriteSheet;
        private Texture2D smallBrickSheet;

        private Texture2D UnderwaterBlockSpriteSheet;
        private Texture2D SeaWeedSpriteSheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();
        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            StairSpriteSheet = content.Load<Texture2D>("StairBlockSheet");
            UsedSpriteSheet = content.Load<Texture2D>("UsedBlockSheet");
            QuestionSpriteSheet = content.Load<Texture2D>("QuestionBlockSheet");
            BrickSpriteSheet = content.Load<Texture2D>("BrickBlockSheet");
            RockSpriteSheet = content.Load<Texture2D>("RockBlockSheet");
            smallBrickSheet = content.Load<Texture2D>("smallbrick");
            UnderwaterBlockSpriteSheet = content.Load<Texture2D>("UnderwaterBlockSPrite");
            SeaWeedSpriteSheet = content.Load<Texture2D>("SeaWeed");
        }
        public int StairBlockWidth
        {
            get
            {
                return StairSpriteSheet.Width / StairSpriteSheetColum;
            }
        }
        public int StairBlockHeight
        {
            get
            {
                return StairSpriteSheet.Height / StairSpriteSheetRows;
            }
        }

        public int UsedBlockWidth
        {
            get
            {
                return UsedSpriteSheet.Width / UsedSpriteSheetColum;
            }
        }
        public int UsedBlockHeight
        {
            get
            {
                return UsedSpriteSheet.Height / UsedSpriteSheetRows;
            }
        }

        public int QuestionBlockWidth
        {
            get
            {
                return QuestionSpriteSheet.Width / QuestionSpriteSheetColum;
            }
        }
        public int QuestionBlockHeight
        {
            get
            {
                return QuestionSpriteSheet.Height / QuestionSpriteSheetRows;
            }
        }

        public int BrickBlockWidth
        {
            get
            {
                return BrickSpriteSheet.Width / BrickSpriteSheetColum;
            }
        }
        public int BrickBlockHeight
        {
            get
            {
                return BrickSpriteSheet.Height / BrickSpriteSheetRows;
            }
        }

        public int RockBlockWidth
        {
            get
            {
                return RockSpriteSheet.Width / RockSpriteSheetColum;
            }
        }
        public int RockBlockHeight
        {
            get
            {
                return RockSpriteSheet.Height / RockSpriteSheetRows;
            }
        }
        public int UnderwaterBlockWidth
        {
            get
            {
                return UnderwaterBlockSpriteSheet.Width / UnderwaterBlockSpriteColumns;
            }
        }
        public int UnderwaterBlockHeight
        {
            get
            {
                return UnderwaterBlockSpriteSheet.Height / UnderwaterBlockSpriteRows;
            }
        }

        public int SeaWeedWidth
        {
            get
            {
                return SeaWeedSpriteSheet.Width / SeaWeedSpriteColumns;
            }
        }

        public int SeaWeedHeight
        {
            get
            {
                return SeaWeedSpriteSheet.Height / SeaweedSpriteRows;
            }
        }

        public ISprite CreateStairBlock()
        {
            return new StairBlockSprite(StairSpriteSheet) ;
        }

        public ISprite CreateUsedBlock()
        {
            return new UsedBlockSprite(UsedSpriteSheet) ;
        }

        public ISprite CreateSmallBrickBlockSprite()
        {
            return new SmallBrickSprite(smallBrickSheet) ;
        }

        public ISprite CreateQuestionBlock()
        {
            return new QuestionBlockSprite(QuestionSpriteSheet) ;
        }

        public ISprite CreateBrickBlock()
        {
            return new BrickBlockSprite(BrickSpriteSheet);
        }

        public ISprite CreateRockBlock()
        {
            return new RockBlockSprite(RockSpriteSheet) ;
        }
        public ISprite CreateHiddenBlock()
        {
            return new HiddenBlockSprite(UsedSpriteSheet);
        }

        public ISprite CreateUnderwaterBlock()
        {
            return new UnderwaterBlockSprite(UnderwaterBlockSpriteSheet);
        }

        public ISprite CreateSeaWeed()
        {
            return new SeaWeedSprite(SeaWeedSpriteSheet);
        }

        public Vector2 UsedBlockAnimation1 { get; } = new Vector2(0, 0);
        public Vector2 QuestionBlockAnimation1 { get; } = new Vector2(0, 0);
        public Vector2 BrickBlockAnimation1 { get; } = new Vector2(0, 0);
        public Vector2 RockBlockAnimation1 { get; } = new Vector2(0, 0);
        public Vector2 UnderwaterBlockAnimation1 { get; } = new Vector2(0, 0);


    }
}
