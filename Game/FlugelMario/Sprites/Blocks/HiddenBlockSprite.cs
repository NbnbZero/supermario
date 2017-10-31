using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Blocks
{
    class HiddenBlockSprite : Sprite
    {
        public HiddenBlockSprite(Texture2D texture) : base(texture)
        {
            Width = BlockSpriteFactory.Instance.UsedBlockWidth;
            Height = BlockSpriteFactory.Instance.UsedBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.Y;
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
        }
    }
}