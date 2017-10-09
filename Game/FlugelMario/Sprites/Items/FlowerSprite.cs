using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Items
{
    class FlowerSprite : Sprite
    {
        public FlowerSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = ItemSpriteFactory.Instance.FlowerWith; // TODO: Correct spelling
            Height = ItemSpriteFactory.Instance.FlowerHeight;

            TextureX = (int)ItemSpriteFactory.Instance.FlowerAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.FlowerAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.FlowerAnimeTotalFrame;
        }
        
        public override void Update()
        {
            Animate();
        }
    }
}