using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Items;

namespace SuperMario.Sprites.Blocks
{
    class QuestionBlockSprite : BlockSprite
    {
        public ItemSprite Item;

        public QuestionBlockSprite(Texture2D texture, Vector2 location, ItemSprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            Height = BlockSpriteFactory.Instance.QuestionBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;

            Item = item;
        }

        public override void Update()
        {
            Animate();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Item.Draw(spriteBatch, Item.Location);
            base.Draw(spriteBatch, location);
        }
    }
}
