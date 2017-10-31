using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;

namespace SuperMario.Sprites.Koopa
{
    class KoopaSprite : Sprite
    {
        private bool goLeft;
        private bool goRight;
        public KoopaSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.KoopaWidth;
            Height = EnemySpriteFactory.Instance.KoopaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.KoopaWalkCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.KoopaWalkCord.Y;

            TotalFrames = EnemySpriteFactory.Instance.KoopaWalkTotalFrame;

            Alive = true;
            goLeft = false;
            goRight = false;
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
