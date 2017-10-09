using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMario.Interfaces
{
    public interface IEnemyState
    {
        Sprite StateSprite { get; set; }
        void Update();
        void Terminate();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
