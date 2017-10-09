using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.StairBlocks
{
    class StairBlockSprite : Sprite
    {
        public StairBlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = BlockSpriteFactory.Instance.StairBlockWidth;
            Height = BlockSpriteFactory.Instance.StairBlockHeight;
        }

        public override void Update()
        {
            //Animate();
        }
    }
}
