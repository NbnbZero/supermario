using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Items;
using FlugelMario;

namespace SuperMario.Sprites.Blocks
{
    class UsedBlockSprite : BlockSprite
    {
        public UsedBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.UsedBlockWidth;
            Height = BlockSpriteFactory.Instance.UsedBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.UsedBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.UsedBlockAnimeTotalFrame;

            SetItem(item);
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
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
                GetItem().Reveal();
            }
        }
    }
}
