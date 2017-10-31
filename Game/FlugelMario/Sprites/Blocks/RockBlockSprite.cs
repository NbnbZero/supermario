using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;

namespace SuperMario.Sprites.Blocks
{
    class RockBlockSprite:Sprite
    {
        public RockBlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.RockBlockWidth;
            Height = BlockSpriteFactory.Instance.RockBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.RockBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.RockBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.RockBlockAnimeTotalFrame;
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
        }
    }
}
