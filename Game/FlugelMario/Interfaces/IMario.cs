using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces 
{
    public interface IMario: IGameObject
    {
        IMarioState State { get; set; }
        bool IsProtected { get; set; }
        Vector2 Velocity { get; set; }
    }
}
