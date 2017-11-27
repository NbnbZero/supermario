﻿using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperMario.Sprites
{
    class IdleInWaterRightFireMarioSprite : MarioSprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.IdleInWaterRightFireMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.IdleInWaterRightFireMarioCord.Y;

        public IdleInWaterRightFireMarioSprite(Texture2D texture) : base(texture)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = TextureX * bigSwimMarioWidth;
            int y = TextureY * bigSwimMarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
