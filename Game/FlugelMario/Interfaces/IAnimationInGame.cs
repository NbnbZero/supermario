using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IAnimationInGame
    {
        Vector2 Location { set; get; }
        Vector2 Velocity { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void StartAnimation();
    }
}
