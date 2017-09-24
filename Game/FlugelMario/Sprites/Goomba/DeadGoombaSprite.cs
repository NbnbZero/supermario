using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Sprites.Goomba
{
    class DeadGoombaSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int GoombaWidth = EnemySpriteFactory.Instance.GoombaWidth;
        private int GoombaHeight = EnemySpriteFactory.Instance.GoombaHeight;
        private int TextureX = (int)EnemySpriteFactory.Instance.GoombaDeadCord.X;
        private int TextureY = (int)EnemySpriteFactory.Instance.GoombaDeadCord.Y;

        public DeadGoombaSprite(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {
            Destination = MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Location = location;
            sourceRectangle = new Rectangle(TextureX * GoombaWidth, TextureY * GoombaHeight, GoombaWidth, GoombaHeight);
            Destination = new Rectangle((int)location.X, (int)location.Y, GoombaWidth, GoombaHeight);


            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);

        }
        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, GoombaWidth, GoombaHeight);
        }
    }
}
