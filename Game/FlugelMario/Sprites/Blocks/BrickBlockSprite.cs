using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sprites.Items;

namespace SuperMario.Sprites.Blocks
{
    class BrickBlockSprite : BlockSprite
    {
        public BrickBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.BrickBlockWidth;
            Height = BlockSpriteFactory.Instance.BrickBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.BrickBlockAnimeTotalFrame;

            SetItem(item);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (GetItem() != null)
            {
                GetItem().Draw(spriteBatch, GetItem().Location);
                base.Draw(spriteBatch, location);
            }
        }

        public override void RespondToCollision(CollisionDirection direction)
        {
            if (direction == CollisionDirection.Bottom)
            {
                BumpUp();
                Animate();
                GetItem().Reveal();
            }
        }
    }
}
