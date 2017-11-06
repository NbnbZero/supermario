using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMario.Interfaces
{
    public interface IEnemyState
    {
        ISprite StateSprite { get; set; }
        void Update();
        void Terminate(String direction);
        void ChangeDirection();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
