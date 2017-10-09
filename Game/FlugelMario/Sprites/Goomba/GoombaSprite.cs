using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario;

namespace SuperMario.Sprites.Goomba
{
    class GoombaSprite : Sprite
    {
        public GoombaSprite(Texture2D texture, Vector2 location = default(Vector2)) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.GoombaWidth;
            Height = EnemySpriteFactory.Instance.GoombaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.GoombaWalkCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.GoombaWalkCord.Y;

            TotalFrames = EnemySpriteFactory.Instance.GoombaWalkTotalFrame;

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
