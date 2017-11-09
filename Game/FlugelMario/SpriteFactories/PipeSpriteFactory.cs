using FlugelMario.Sprites.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.SpriteFactories
{
    public class PipeSpriteFactory
    {
        public static int PipeSpriteSheetRows { get; } = 1;
        public static int PipeSpriteColumn { get; } = 4;

        private Texture2D PipeSheet;
        private Texture2D pipeSheet2;
        private Texture2D lPipeSheet;
        private Texture2D LPipeBottomSheet;
        private Texture2D LPipeTopSheet;
        private Texture2D LPipeBottomSheetLeft;
        private Texture2D LPipeTopSheetLeft;

        private static PipeSpriteFactory instance = new PipeSpriteFactory();

        public static PipeSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PipeSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            PipeSheet = content.Load<Texture2D>("pipe_sheet");
            pipeSheet2 = content.Load<Texture2D>("pipes");
            lPipeSheet = content.Load<Texture2D>("lPipe");
            LPipeBottomSheet = content.Load<Texture2D>("LPipeBottom");
            LPipeTopSheet = content.Load<Texture2D>("LPipeTop");
            LPipeBottomSheetLeft = content.Load<Texture2D>("LPipeBottomLeft");
            LPipeTopSheetLeft = content.Load<Texture2D>("LPipeTopLeft");
        }

        public ISprite CreatePipeSprite()
        {
            return new PipeSprite(PipeSheet);
        }
        public ISprite CreateMediumPipeSprite()
        {
            return new MediumPipeSprite(pipeSheet2);
        }
        public ISprite CreateBigPipeSprite()
        {
            return new BigPipeSprite(pipeSheet2);
        }
        public ISprite CreateLPipeSprite()
        {
            return new LPipeSprite(lPipeSheet);
        }

        public ISprite CreateLPipeBottomSprite()
        {
            return new LPipeBottomSprite(LPipeBottomSheet);
        }

        public ISprite CreateLPipeTopSprite()
        {
            return new LPipeTopSprite(LPipeTopSheet);
        }
        public ISprite CreateLPipeBottomLeftSprite()
        {
            return new LPipeBottomLeftSprite(LPipeBottomSheetLeft);
        }
        public ISprite CreateLPipeTopLeftSprite()
        {
            return new LPipeTopLeftSprite(LPipeTopSheetLeft);
        }
    }
}

