using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.AbstractClasses
{
    public abstract class MarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public int MarioWidth { get; set; } = MarioSpriteFactory.Instance.NormalMarioWidth;
        public int MarioHeight { get; set; } = MarioSpriteFactory.Instance.NormalMarioHeight;

        protected MarioSprite(Texture2D texture)
        {
            Texture = texture;
            SourceRectangle = new Rectangle(0, 0, MarioWidth, MarioHeight);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            SourceRectangle = new Rectangle(SourceRectangle.X, SourceRectangle.Y + 1, MarioWidth, MarioHeight);

            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
                spriteBatch.End();
            }

        }

        public virtual void Update()
        {

        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, MarioWidth * 1, MarioHeight * 1);
        }
    }
}
