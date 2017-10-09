using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;

namespace SuperMario.Interfaces
{
    public interface IGameObject
    {
        Vector2 Location { set; get; }
        Rectangle Destination { get; set; }
        ObjectType Type { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
