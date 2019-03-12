using Microsoft.Xna.Framework;

namespace SuperMario.Interfaces
{
    public interface IItem : IGameObject
    {
        Vector2 Velocity { get; set; }
        bool IsCollected { get; set; }
        void Collect();
        bool IsPreparing { get; set; }
        void ChangeDirection();
        

    }
}