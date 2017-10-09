using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class UsedBlockSprite : Sprite
    {
        public UsedBlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.UsedBlockWidth;
            Height = BlockSpriteFactory.Instance.UsedBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.UsedBlockAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}
