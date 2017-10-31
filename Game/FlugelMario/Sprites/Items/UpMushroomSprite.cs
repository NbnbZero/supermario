using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;

namespace SuperMario.Sprites.Items
{
    class UpMushroomSprite : ItemSprite
    {
        private bool goLeft;
        private bool goRight;

        public UpMushroomSprite(Texture2D texture, Vector2 location, bool hidden) : base(texture, location, hidden)
        {
            Width = ItemSpriteFactory.Instance.UpMushroomWith;
            Height = ItemSpriteFactory.Instance.UpMushroomHeight;

            TextureX = (int)ItemSpriteFactory.Instance.UpMushroomAnimation1.X;
            TextureY = (int)ItemSpriteFactory.Instance.UpMushroomAnimation1.Y;

            TotalFrames = ItemSpriteFactory.Instance.UpMushroomAnimeTotalFrame;
            goLeft = false;
            goRight = false;
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
            goLeft = Location.X < (marioLocation.X + viewport.Width / 2) && Location.X > marioLocation.X;
            goRight = Location.X < marioLocation.X;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (goLeft)
            {
                Location = new Vector2(Location.X - 1, Location.Y);
            }
            else if (goRight)
            {
                Location = new Vector2(Location.X + 1, Location.Y);
            }
            base.Draw(spriteBatch, location);
        }


    }
}