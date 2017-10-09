using Microsoft.Xna.Framework;
using System;

namespace SuperMario.Interfaces
{
    public interface IEnemy : IGameObject
    {
        IEnemyState State { get; set; }
        bool Alive { get; set; }
        void Terminate();
    }
}
