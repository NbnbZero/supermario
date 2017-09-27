using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }       
        Rectangle MakeDestinationRectangle(Vector2 location);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
