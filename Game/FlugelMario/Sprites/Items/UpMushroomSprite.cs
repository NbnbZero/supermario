using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Items
{
    class UpMushroomSprite : ItemSprite
    {
        public UpMushroomSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = ItemSpriteFactory.Instance.UpMushroomWith;
            Height = ItemSpriteFactory.Instance.UpMushroomHeight;

            TextureX = (int)ItemSpriteFactory.Instance.UpMushroomAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.UpMushroomAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.UpMushroomAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}