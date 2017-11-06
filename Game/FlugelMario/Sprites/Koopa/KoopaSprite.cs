using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;

namespace SuperMario.Sprites.Koopa
{
    class KoopaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int KoopaWidth = EnemySpriteFactory.Instance.KoopaWidth;
        private int KoopaHeight = EnemySpriteFactory.Instance.KoopaHeight;
        private int TextureX = (int)EnemySpriteFactory.Instance.KoopaWalkCord.X;
        private int TextureY = (int)EnemySpriteFactory.Instance.KoopaWalkCord.Y;
        private int currentFrame;
        private int TotalFrames = EnemySpriteFactory.Instance.GoombaWalkTotalFrame;
        private int Counter = 0;

        public KoopaSprite(Texture2D texture)
        {
            currentFrame = 0;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle((TextureX + currentFrame) * KoopaWidth, TextureY * KoopaHeight, KoopaWidth, KoopaHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
        }

        public void Update()
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

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, KoopaWidth, KoopaHeight);
        }
    }
}
