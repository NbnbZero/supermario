using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Blocks
{
    class QuestionBlockSprite : Sprite
    {
        public QuestionBlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.QuestionBlockWidth;
            Height = BlockSpriteFactory.Instance.QuestionBlockHeight;

            TextureX = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.X;
            TextureY = (int)BlockSpriteFactory.Instance.QuestionBlockAnimation1.Y;

            TotalFrames = BlockSpriteFactory.Instance.QuestionBlockAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}
