using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Items
{
    class FlowerSprite : ItemSprite
    {
        public FlowerSprite(Texture2D texture, Vector2 location, bool hidden) : base(texture, location, hidden)
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