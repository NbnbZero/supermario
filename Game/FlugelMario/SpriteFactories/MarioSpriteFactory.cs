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
        public int NormalMarioSpriteSheetRow { get; } = 2;
        public int NormalMarioSpriteRunningSheetColumn { get; } = 3;
        public int BigMarioSpriteSheetColumn { get; } = 14;
        public int BigMarioSpriteSheetRow { get; } = 2;

        private Texture2D normalMarioSpriteSheet;
        private Texture2D bigMarioSpriteSheet;

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
            if (content != null)
            {
                normalMarioSpriteSheet = content.Load<Texture2D>("SmallMario");
                bigMarioSpriteSheet = content.Load<Texture2D>("BigMario");
            }
        }

        public int NormalMarioWidth
        {
            get
            {
                return normalMarioSpriteSheet.Width / NormalMarioSpriteSheetColumn;
            }
        }

        public int NormalMarioHeight
        {
            get
            {
                return normalMarioSpriteSheet.Height / NormalMarioSpriteSheetRow;
            }
        }

        public int BigMarioWidth
        {
            get
            {
                return bigMarioSpriteSheet.Width / BigMarioSpriteSheetColumn;
            }
        }

        public int BigMarioHeight
        {
            get
            {
                return bigMarioSpriteSheet.Height / BigMarioSpriteSheetRow;
            }
        }

        public Vector2 CrouchLeftBigMarioCord { get; } = new Vector2(6, 0);
        public Vector2 CrouchLeftFireMarioCord { get; } = new Vector2(6, 1);
        public Vector2 CrouchRightBigMarioCord { get; } = new Vector2(7, 0);
        public Vector2 CrouchRightFireMarioCord { get; } = new Vector2(7, 1);
        public Vector2 DeadMarioCord { get; } = new Vector2(7, 0);
        public Vector2 IdleLeftBigMarioCord { get; } = new Vector2(5, 0);
        public Vector2 IdleLeftFireMarioCord { get; } = new Vector2(5, 1);
        public Vector2 IdleLeftSmallMarioCord { get; } = new Vector2(5, 0);
        public Vector2 IdleRightBigMarioCord { get; } = new Vector2(8, 0);
        public Vector2 IdleRightFireMarioCord { get; } = new Vector2(8, 1);
        public Vector2 IdleRightSmallMarioCord { get; } = new Vector2(8, 0);
        public Vector2 JumpLeftBigMarioCord { get; } = new Vector2(0, 0);
        public Vector2 JumpLeftFireMarioCord { get; } = new Vector2(0, 1);
        public Vector2 JumpLeftSmallMarioCord { get; } = new Vector2(0, 0);
        public Vector2 JumpRightBigMarioCord { get; } = new Vector2(13, 0);
        public Vector2 JumpRightFireMarioCord { get; } = new Vector2(13, 1);
        public Vector2 JumpRightSmallMarioCord { get; } = new Vector2(13, 0);
        public Vector2 RunningLeftBigMarioCord { get; } = new Vector2(3, 0);
        public Vector2 RunningLeftFireMarioCord { get; } = new Vector2(3, 1);
        public Vector2 RunningLeftSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 RunningRightBigMarioCord { get; } = new Vector2(10, 0);
        public Vector2 RunningRightFireMarioCord { get; } = new Vector2(10, 1);
        public Vector2 RunningRightSmallMarioCord { get; } = new Vector2(10, 0);

        public Sprite CreateCrouchLeftBigMarioSprite(Vector2 location)
        {
            return new CrouchLeftBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateCrouchLeftFireMarioSprite(Vector2 location)
        {
            return new CrouchLeftFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateCrouchRightBigMarioSprite(Vector2 location)
        {
            return new CrouchRightBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateCrouchRightFireMarioSprite(Vector2 location)
        {
            return new CrouchRightFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateDeadMarioSprite(Vector2 location)
        {
            return new DeadMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateIdleLeftBigMarioSprite(Vector2 location)
        {
            return new IdleLeftBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateIdleLeftFireMarioSprite(Vector2 location)
        {
            return new IdleLeftFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateIdleLeftSmallMarioSprite(Vector2 location)
        {
            return new IdleLeftSmallMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateIdleRightBigMarioSprite(Vector2 location)
        {
            return new IdleRightBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateIdleRightFireMarioSprite(Vector2 location)
        {
            return new IdleRightFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateIdleRightSmallMarioSprite(Vector2 location)
        {
            return new IdleRightSmallMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateJumpLeftBigMarioSprite(Vector2 location)
        {
            return new JumpLeftBigMarioSprite(bigMarioSpriteSheet, location);
        }
        public Sprite CreateJumpLeftFireMarioSprite(Vector2 location)
        {
            return new JumpLeftFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateJumpLeftSmallMarioSprite(Vector2 location)
        {
            return new JumpLeftSmallMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateJumpRightBigMarioSprite(Vector2 location)
        {
            return new JumpRightBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateJumpRightFireMarioSprite(Vector2 location)
        {
            return new JumpRightFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateJumpRightSmallMarioSprite(Vector2 location)
        {
            return new JumpRightSmallMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateRunningLeftBigMarioSprite(Vector2 location)
        {
            return new RunningLeftBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateRunningLeftFireMarioSprite(Vector2 location)
        {
            return new RunningLeftFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateRunningLeftSmallMarioSprite(Vector2 location)
        {
            return new RunningLeftSmallMarioSprite(normalMarioSpriteSheet, location);
        }

        public Sprite CreateRunningRightBigMarioSprite(Vector2 location)
        {
            return new RunningRightBigMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateRunningRightFireMarioSprite(Vector2 location)
        {
            return new RunningRightFireMarioSprite(bigMarioSpriteSheet, location);
        }

        public Sprite CreateRunningRightSmallMarioSprite(Vector2 location)
        {
            return new RunningRightSmallMarioSprite(normalMarioSpriteSheet, location);
        }
    }
}
