using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Items;
using FlugelMario;

namespace SuperMario.Sprites.Blocks
{
    class QuestionBlockSprite : BlockSprite
    {

        public QuestionBlockSprite(Texture2D texture, Vector2 location, Items.ISprite item) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            Height = BlockSpriteFactory.Instance.QuestionBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;

            SetItem(item);
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            GetItem().Draw(spriteBatch, GetItem().Location);
            base.Draw(spriteBatch, location);
        }
    }
}
