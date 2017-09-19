using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint1Game.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Sprites
{
    class CrouchLeftBigMarioSprite : ISprite
    {
        private int TextureX = (int)MarioSpriteFactory.Instance.CrouchLeftBigMarioCord.X;
        private int TextureY = (int)MarioSpriteFactory.Instance.CrouchLeftBigMarioCord.Y;

        public CrouchLeftBigMarioSprite(Texture2D texture) : base(texture)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 marioLocation)
        {
            int x = TextureX * MarioWidth;
            int y = TextureY * MarioHeight;
            int width = SourceRectangle.Width;
            int height = SourceRectangle.Height;
            SourceRectangle = new Rectangle(x, y, width, height);
            base.Draw(spriteBatch, marioLocation);
        }
    }
}
