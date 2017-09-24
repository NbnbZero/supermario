using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Koopa
{
    class KoopaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int KoopaWidth = EnemySpriteFactory.Instance.KoopaWidth;
        private int KoopaHeight = EnemySpriteFactory.Instance.KoopaHeight;
        private int TextureX = (int)EnemySpriteFactory.Instance.KoopaWalkCord.X;
        private int TextureY = (int)EnemySpriteFactory.Instance.KoopaWalkCord.Y;
        private int currentFrame;
        private int TotalFrames = EnemySpriteFactory.Instance.GoombaWalkTotalFrame;
        private int counter = 0;

        public KoopaSprite(Texture2D texture)
        {
            currentFrame = 0;
            Texture = texture;
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
            sourceRectangle = new Rectangle((TextureX + currentFrame) * KoopaWidth, TextureY * KoopaHeight, KoopaWidth, KoopaHeight);
            Destination = MakeDestinationRectangle(location);


            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);

        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, KoopaWidth, KoopaHeight);
        }
    }
}
