using Microsoft.Xna.Framework;
using System;

namespace SuperMario.Interfaces
{
    public interface IEnemy : IGameObject
    {
        IEnemyState State { get; set; }
        bool CanUpdate();
        bool Alive { get; set; }
        bool Moving { get; set; }
        Vector2 Velocity { get; set; }
        void Terminate(String direction);
        void ChangeDirection();
    }
}
