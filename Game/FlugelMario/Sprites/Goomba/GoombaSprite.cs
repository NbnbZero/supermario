using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario;
using FlugelMario;

namespace SuperMario.Sprites.Goomba
{
    class GoombaSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public Rectangle Destination { get; set; }

        private Rectangle sourceRectangle;
        private int GoombaWidth = EnemySpriteFactory.Instance.GoombaWidth;
        private int GoombaHeight = EnemySpriteFactory.Instance.GoombaHeight;
        private int TextureX = (int)EnemySpriteFactory.Instance.GoombaWalkCord.X;
        private int TextureY = (int)EnemySpriteFactory.Instance.GoombaWalkCord.Y;
        private int currentFrame;
        private int TotalFrames = EnemySpriteFactory.Instance.GoombaWalkTotalFrame;
        private int counter = 0;

        public GoombaSprite(Texture2D texture)
        {
            currentFrame = 0;
            this.Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle((TextureX + currentFrame) * GoombaWidth, TextureY * GoombaHeight, GoombaWidth, GoombaHeight);
            Destination = MakeDestinationRectangle(location);


            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
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

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, GoombaWidth, GoombaHeight);
        }
    }
}
