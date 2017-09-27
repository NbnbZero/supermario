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

        private Texture2D normalMarioSpriteSheet;

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
                normalMarioSpriteSheet = content.Load<Texture2D>("Mariosheet");
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

        public Vector2 CrouchLeftBigMarioCord { get; } = new Vector2(6, 1);
        public Vector2 CrouchLeftFireMarioCord { get; } = new Vector2(6, 2);
        public Vector2 CrouchRightBigMarioCord { get; } = new Vector2(7, 1);
        public Vector2 CrouchRightFireMarioCord { get; } = new Vector2(7, 2);
        public Vector2 DeadMarioCord { get; } = new Vector2(7, 0);
        public Vector2 IdleLeftBigMarioCord { get; } = new Vector2(5, 1);
        public Vector2 IdleLeftFireMarioCord { get; } = new Vector2(5, 2);
        public Vector2 IdleLeftSmallMarioCord { get; } = new Vector2(5, 0);
        public Vector2 IdleRightBigMarioCord { get; } = new Vector2(8, 1);
        public Vector2 IdleRightFireMarioCord { get; } = new Vector2(8, 2);
        public Vector2 IdleRightSmallMarioCord { get; } = new Vector2(8, 0);
        public Vector2 JumpLeftBigMarioCord { get; } = new Vector2(0, 1);
        public Vector2 JumpLeftFireMarioCord { get; } = new Vector2(0, 2);
        public Vector2 JumpLeftSmallMarioCord { get; } = new Vector2(0, 0);
        public Vector2 JumpRightBigMarioCord { get; } = new Vector2(13, 1);
        public Vector2 JumpRightFireMarioCord { get; } = new Vector2(13, 2);
        public Vector2 JumpRightSmallMarioCord { get; } = new Vector2(13, 0);
        public Vector2 RunningLeftBigMarioCord { get; } = new Vector2(3, 1);
        public Vector2 RunningLeftFireMarioCord { get; } = new Vector2(3, 2);
        public Vector2 RunningLeftSmallMarioCord { get; } = new Vector2(3, 0);
        public Vector2 RunningRightBigMarioCord { get; } = new Vector2(10, 1);
        public Vector2 RunningRightFireMarioCord { get; } = new Vector2(10, 2);
        public Vector2 RunningRightSmallMarioCord { get; } = new Vector2(10, 0);

        public ISprite CreateCrouchLeftBigMarioSprite()
        {
            return new CrouchLeftBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchLeftFireMarioSprite()
        {
            return new CrouchLeftFireMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchRightBigMarioSprite()
        {
            return new CrouchRightBigMarioSprite(this.normalMarioSpriteSheet);
        }

        public ISprite CreateCrouchRightFireMarioSprite()
        {
            return new CrouchRightFireMarioSprite(this.normalMarioSpriteSheet);
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
    }
}
