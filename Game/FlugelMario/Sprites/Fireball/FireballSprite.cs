using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;

namespace SuperMario.Sprites.Fireball
{
    public class FireballSprite: Sprite
    {
        public FireballSprite(Texture2D texture) : base(texture)
        {
            Width = FireballSpriteFactory.Instance.FireballWidth;
            Height = FireballSpriteFactory.Instance.FireballHeight;

            TextureX = (int)FireballSpriteFactory.Instance.FireballSpriteCord.X;
            TextureY = (int)FireballSpriteFactory.Instance.FireballSpriteCord.Y;

            TotalFrames = FireballSpriteFactory.Instance.FireballTotalFrame;
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Animate();
        }
    }
}
