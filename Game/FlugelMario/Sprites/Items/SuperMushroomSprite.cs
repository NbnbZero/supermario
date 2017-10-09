using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Items
{
    class SuperMushroomSprite : Sprite
    {
        public SuperMushroomSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = ItemSpriteFactory.Instance.SuperMushroomWith;
            Height = ItemSpriteFactory.Instance.SuperMushroomHeight;

            TextureX = (int)ItemSpriteFactory.Instance.SuperMushroomAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.SuperMushroomAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.SuperMushroomAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}
