using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Items
{
    class CoinSprite : ItemSprite
    {
        public CoinSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = ItemSpriteFactory.Instance.CoinWith; // TODO: Correct spelling
            Height = ItemSpriteFactory.Instance.CoinHeight;

            TextureX = (int)ItemSpriteFactory.Instance.CoinAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.CoinAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.CoinAnimeTotalFrame;
        }

        public override void Update()
        {
            Animate();
        }
    }
}