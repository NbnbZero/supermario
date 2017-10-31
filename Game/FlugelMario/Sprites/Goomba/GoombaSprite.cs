using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario;
using FlugelMario;

namespace SuperMario.Sprites.Goomba
{
    class GoombaSprite : Sprite
    {
        private bool goLeft;
        private bool goRight;

        public GoombaSprite(Texture2D texture, Vector2 location = default(Vector2)) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.GoombaWidth;
            Height = EnemySpriteFactory.Instance.GoombaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.GoombaWalkCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.GoombaWalkCord.Y;

            TotalFrames = EnemySpriteFactory.Instance.GoombaWalkTotalFrame;

            Alive = true;
            goLeft = false;
            goRight = false;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (goLeft)
            {
                Location = new Vector2(Location.X - 1, Location.Y);
            } else if (goRight)
            {
                Location = new Vector2(Location.X + 1, Location.Y);
            }
            base.Draw(spriteBatch, location);
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Destination = MakeDestinationRectangle(Location);
            if (Counter % 10 == 0)
            {
                CurrentFrame++;
                CurrentFrame = CurrentFrame % TotalFrames;
                Counter = 0;
            }
            Counter++;

            goLeft = Location.X < (marioLocation.X + viewport.Width / 2) && Location.X > marioLocation.X;
            goRight = Location.X < marioLocation.X;
        }
    }
}
