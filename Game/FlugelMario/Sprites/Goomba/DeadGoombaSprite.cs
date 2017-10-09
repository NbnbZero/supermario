using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Goomba
{
    class DeadGoombaSprite : Sprite
    {
        public DeadGoombaSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.GoombaWidth;
            Height = EnemySpriteFactory.Instance.GoombaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.GoombaDeadCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.GoombaDeadCord.Y;
        }

        public override void Update()
        {
            Destination = MakeDestinationRectangle(Location);
        }
    }
}
