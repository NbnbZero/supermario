using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class BrickBlockSprite : BlockSprite
    {
        public BrickBlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.BrickBlockWidth;
            Height = BlockSpriteFactory.Instance.BrickBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.BrickBlockAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}
