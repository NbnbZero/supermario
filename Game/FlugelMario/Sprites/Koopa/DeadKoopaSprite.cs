using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Sprites.Koopa
{
    class DeadKoopaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        Rectangle sourceRectangle;
        private int KoopaWidth = EnemySpriteFactory.Instance.KoopaWidth;
        private int KoopaHeight = EnemySpriteFactory.Instance.KoopaHeight;
        private int TextureX = (int)EnemySpriteFactory.Instance.KoopaDeadCord.X;
        private int TextureY = (int)EnemySpriteFactory.Instance.KoopaDeadCord.Y;

        public DeadKoopaSprite(Texture2D texture)
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
            sourceRectangle = new Rectangle(TextureX * KoopaWidth, TextureY * KoopaHeight, KoopaWidth, KoopaHeight);
            Destination = MakeDestinationRectangle(location);

            if (spriteBatch != null)
            {
                spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
            }

        }


        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, KoopaWidth, KoopaHeight);
        }
    }
}
