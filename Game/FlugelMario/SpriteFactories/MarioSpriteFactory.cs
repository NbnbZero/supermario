using SuperMario.Interfaces;
using SuperMario.Sprites;
using SuperMario.Sprites.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMario.SpriteFactories
{
    public class MarioSpriteFactory
    {
        public int NormalMarioSpriteSheetColumn { get; } = 14;
        public int NormalMarioSpriteSheetRow { get; } = 4;
        public int NormalMarioSpriteRunningSheetColumn { get; } = 3;
        public int NormalMarioSpriteSwimmingSheetColumn { get; } = 4;
        public int BigMarioSpriteSwimmingSheetColumn { get; } = 5;
        public int StarMarioSpriteSheetRow { get; } = 8;
        public int SmallMarioSwimSheetColumn { get; } = 8;
        public int SmallMarioSwimSheetRow { get; } = 1;
        public int BigMarioSwimSheetColumn { get; } = 12;
        public int BigMarioSwimSheetRow { get; } = 3;

        private Texture2D normalMarioSpriteSheet;
        private Texture2D starMarioSpriteSheet;
        private Texture2D smallMarioSwimSheet;
        private Texture2D bigMarioSwimSheet;

        private static MarioSpriteFactory instance = new MarioSpriteFactory();

        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            normalMarioSpriteSheet = content.Load<Texture2D>("Mariosheet");
            starMarioSpriteSheet = content.Load<Texture2D>("mario_sheet_star");
            smallMarioSwimSheet = content.Load<Texture2D>("SmallMarioSwim");
            bigMarioSwimSheet = content.Load<Texture2D>("BigMarioSwim");
        }

        public int NormalMarioWidth
        {
            get
            {
                return normalMarioSpriteSheet.Width / NormalMarioSpriteSheetColumn;
            }
        }

        public int SmallMarioSwimHeight
        {
            get
            {
                return smallMarioSwimSheet.Height / SmallMarioSwimSheetRow;
            }
        }

        public int smallMarioSwimWidth
        {
            get
            {
                return smallMarioSwimSheet.Width / SmallMarioSwimSheetColumn;
            }
        }

        public int NormalMarioHeight
        {
            get
            {
                return normalMarioSpriteSheet.Height / NormalMarioSpriteSheetRow;
            }
        }

        public int BigMarioSwimHeight
        {
            get
            {
                return bigMarioSwimSheet.Height / BigMarioSwimSheetRow;
            }
        }

        public int bigMarioSwimWidth
        {
            get
            {
                return bigMarioSwimSheet.Width / BigMarioSwimSheetColumn;
            }
        }

        public int HalfNormalMarioHeight
        {
            get
            {
                return normalMarioSpriteSheet.Height / NormalMarioSpriteSheetRow / 2;
            }
        }

        public Vector2 CrouchLeftBigMarioCord { get; } = new Vector2(6, 1);
        public Vector2 CrouchLeftFireMarioCord { get; } = new Vector2(6, 2);
        public Vector2 CrouchLeftStarMarioCord { get; } = new Vector2(6, 4);
        public Vector2 CrouchRightBigMarioCord { get; } = new Vector2(7, 1);
        public Vector2 CrouchRightFireMarioCord { get; } = new Vector2(7, 2);
        public Vector2 CrouchRightStarMarioCord { get; } = new Vector2(7, 4);
        public Vector2 DeadMarioCord { get; } = new Vector2(7, 0);
        public Vector2 IdleLeftBigMarioCord { get; } = new Vector2(5, 1);
        public Vector2 IdleLeftFireMarioCord { get; } = new Vector2(5, 2);
        public Vector2 IdleLeftSmallMarioCord { get; } = new Vector2(5, 0);
        public Vector2 IdleLeftStarBigMarioCord { get; } = new Vector2(5, 4);
        public Vector2 IdleLeftStarSmallMarioCord { get; } = new Vector2(5, 0);
        public Vector2 IdleRightBigMarioCord { get; } = new Vector2(8, 1);
        public Vector2 IdleRightFireMarioCord { get; } = new Vector2(8, 2);
        public Vector2 IdleRightSmallMarioCord { get; } = new Vector2(8, 0);
        public Vector2 IdleRightStarBigMarioCord { get; } = new Vector2(8, 4);
        public Vector2 IdleRightStarSmallMarioCord { get; } = new Vector2(8, 0);
        public Vector2 JumpLeftBigMarioCord { get; } = new Vector2(0, 1);
        public Vector2 JumpLeftFireMarioCord { get; } = new Vector2(0, 2);
        public Vector2 JumpLeftSmallMarioCord { get; } = new Vector2(0, 0);
        public Vector2 JumpLeftStarBigMarioCord { get; } = new Vector2(0, 4);
        public Vector2 JumpLeftStarSmallMarioCord { get; } = new Vector2(0, 0);
        public Vector2 JumpRightBigMarioCord { get; } = new Vector2(13, 1);
        public Vector2 JumpRightFireMarioCord { get; } = new Vector2(13, 2);
        public Vector2 JumpRightSmallMarioCord { get; } = new Vector2(13, 0);
        public Vector2 JumpRightStarBigMarioCord { get; } = new Vector2(13, 4);
        public Vector2 JumpRightStarSmallMarioCord { get; } = new Vector2(13, 0);
        public Vector2 RunningLeftBigMarioCord { get; } = new Vector2(3, 1);
        public Vector2 RunningLeftFireMarioCord { get; } = new Vector2(3, 2);
        public Vector2 RunningLeftSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 RunningLeftStarBigMarioCord { get; } = new Vector2(3, 4);
        public Vector2 RunningLeftStarSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 RunningRightBigMarioCord { get; } = new Vector2(10, 1);
        public Vector2 RunningRightFireMarioCord { get; } = new Vector2(12, 2);
        public Vector2 RunningRightSmallMarioCord { get; } = new Vector2(10, 0);
        public Vector2 RunningRightStarBigMarioCord { get; } = new Vector2(10, 4);
        public Vector2 RunningRightStarSmallMarioCord { get; } = new Vector2(10, 0);
        public Vector2 SwimmingLeftBigMarioCord { get; } = new Vector2(5, 0);
        public Vector2 SwimmingLeftFireMarioCord { get; } = new Vector2(5, 2);
        public Vector2 SwimmingLeftSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 SwimmingRightBigMarioCord { get; } = new Vector2(6, 0);
        public Vector2 SwimmingRightFireMarioCord { get; } = new Vector2(6, 2);
        public Vector2 SwimmingRightSmallMarioCord { get; } = new Vector2(4, 0);
        public Vector2 IdleInWaterLeftBigMarioCord { get; } = new Vector2(3, 0);
        public Vector2 IdleInWaterLeftFireMarioCord { get; } = new Vector2(3, 2);
        public Vector2 IdleInWaterLeftSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 IdleInWaterRightBigMarioCord { get; } = new Vector2(8, 0);
        public Vector2 IdleInWaterRightFireMarioCord { get; } = new Vector2(8, 2);
        public Vector2 IdleInWaterRightSmallMarioCord { get; } = new Vector2(4, 0);


        public ISprite CreateCrouchLeftBigMarioSprite()
        {
            return new CrouchLeftBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchLeftFireMarioSprite()
        {
            return new CrouchLeftFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchLeftStarMarioSprite()
        {
            return new CrouchLeftStarMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateCrouchRightBigMarioSprite()
        {
            return new CrouchRightBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchRightFireMarioSprite()
        {
            return new CrouchRightFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchRightStarMarioSprite()
        {
            return new CrouchRightStarMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateDeadMarioSprite()
        {
            return new DeadMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleLeftBigMarioSprite()
        {
            return new IdleLeftBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleLeftFireMarioSprite()
        {
            return new IdleLeftFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleLeftSmallMarioSprite()
        {
            return new IdleLeftSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleLeftStarBigMarioSprite()
        {
            return new IdleLeftStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateIdleLeftStarSmallMarioSprite()
        {
            return new IdleLeftStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateIdleRightBigMarioSprite()
        {
            return new IdleRightBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleRightFireMarioSprite()
        {
            return new IdleRightFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleRightSmallMarioSprite()
        {
            return new IdleRightSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateIdleRightStarBigMarioSprite()
        {
            return new IdleRightStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateIdleRightStarSmallMarioSprite()
        {
            return new IdleRightStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateJumpLeftBigMarioSprite()
        {
            return new JumpLeftBigMarioSprite(this.normalMarioSpriteSheet);
        }
        public ISprite CreateJumpLeftFireMarioSprite()
        {
            return new JumpLeftFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateJumpLeftSmallMarioSprite()
        {
            return new JumpLeftSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateJumpLeftStarBigMarioSprite()
        {
            return new JumpLeftStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateJumpLeftStarSmallMarioSprite()
        {
            return new JumpLeftStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateJumpRightBigMarioSprite()
        {
            return new JumpRightBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateJumpRightFireMarioSprite()
        {
            return new JumpRightFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateJumpRightSmallMarioSprite()
        {
            return new JumpRightSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateJumpRightStarBigMarioSprite()
        {
            return new JumpRightStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateJumpRightStarSmallMarioSprite()
        {
            return new JumpRightStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateRunningLeftBigMarioSprite()
        {
            return new RunningLeftBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningLeftFireMarioSprite()
        {
            return new RunningLeftFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningLeftSmallMarioSprite()
        {
            return new RunningLeftSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningLeftStarBigMarioSprite()
        {
            return new RunningLeftStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateRunningLeftStarSmallMarioSprite()
        {
            return new RunningLeftStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateRunningRightBigMarioSprite()
        {
            return new RunningRightBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningRightFireMarioSprite()
        {
            return new RunningRightFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningRightSmallMarioSprite()
        {
            return new RunningRightSmallMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateRunningRightStarBigMarioSprite()
        {
            return new RunningRightStarBigMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateRunningRightStarSmallMarioSprite()
        {
            return new RunningRightStarSmallMarioSprite(this.starMarioSpriteSheet);
        }

        public ISprite CreateSwimmingLeftSmallMarioSprite()
        {
            return new SwimmingLeftSmallMarioSprite(this.smallMarioSwimSheet);
        }
        public ISprite CreateSwimmingLeftBigMarioSprite()
        {
            return new SwimmingLeftBigMarioSprite(this.bigMarioSwimSheet);
        }

        public ISprite CreateSwimmingLeftFireMarioSprite()
        {
            return new SwimmingLeftFireMarioSprite(this.bigMarioSwimSheet);
        }
        public ISprite CreateSwimmingRightSmallMarioSprite()
        {
            return new SwimmingRightSmallMarioSprite(this.smallMarioSwimSheet);
        }
        public ISprite CreateSwimmingRightBigMarioSprite()
        {
            return new SwimmingRightBigMarioSprite(this.bigMarioSwimSheet);
        }

        public ISprite CreateSwimmingRightFireMarioSprite()
        {
            return new SwimmingRightFireMarioSprite(this.bigMarioSwimSheet);
        }
    }
}
