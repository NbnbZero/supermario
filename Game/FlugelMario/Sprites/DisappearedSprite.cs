using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Sprites.Items;
using FlugelMario;

namespace SuperMario
{
    class DisappearedSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public DisappearedSprite(Texture2D texture)
        {
            this.Texture = texture;
        }
        
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (spriteBatch != null)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
                Rectangle destinationRectangle = MakeDestinationRectangle(new Vector2(0, 0));
                spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.Transparent);
            }
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 0, 0);
        }

        public void Update() { }       
    }
}
