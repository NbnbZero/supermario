using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMario.Sprites.Mario
{
    class RunningLeftBigMarioSprite : MarioRunningSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.RunningLeftBigMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.RunningLeftBigMarioCord.Y;
        public RunningLeftBigMarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            CurrentRunningFrame = TotalRunningFrame - 1;
            RunningFrameIncrement = 1;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = (TextureX - CurrentRunningFrame) * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }

    }
}
