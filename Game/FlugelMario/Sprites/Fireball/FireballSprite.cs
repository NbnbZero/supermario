using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FlugelMario.SpriteFactories;
namespace FlugelMario.Sprites.Fireball
{
    public class FireballSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int RockBlockWtidth = FireballSpriteFactory.Instance.FireballWidth;
        private int RockBlockHeight = FireballSpriteFactory.Instance.FireballHeight;
        private int TextureX = (int)FireballSpriteFactory.Instance.FireballSpriteCord.X;
        private int TextureY = (int)FireballSpriteFactory.Instance.FireballSpriteCord.Y;
        private int currentFrame;
        private int TotalFrames = FireballSpriteFactory.Instance.FireballTotalFrame;
        private int counter = 0;

        public FireballSprite(Texture2D texture)
        {
            currentFrame = 0;
            this.Texture = texture;
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
            if (counter % 10 == 0)
            {
                currentFrame++;
                currentFrame = currentFrame % TotalFrames;
                counter = 0;
            }
            counter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle((TextureX + currentFrame) * RockBlockWtidth, TextureY * RockBlockHeight, RockBlockWtidth, RockBlockHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, RockBlockWtidth, RockBlockHeight);
        }
    }
}
