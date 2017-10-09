using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Koopa
{
    class KoopaSprite : Sprite
    {
        public KoopaSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.KoopaWidth;
            Height = EnemySpriteFactory.Instance.KoopaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.KoopaWalkCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.KoopaWalkCord.Y;

            TotalFrames = EnemySpriteFactory.Instance.KoopaWalkTotalFrame;

            Alive = true;
        }

        public override void Update()
        {
            Destination = MakeDestinationRectangle(Location);

            if (Counter % 10 == 0)
            {
                CurrentFrame++;
                CurrentFrame = CurrentFrame % TotalFrames;
                Counter = 0;
            }
            Counter++;
        }
    }
}
