using SuperMario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IMarioPowerUp
    {
        Shape MarioShape { get; set; }
        Controller KeyboardController { get; set; }
        void Update();
    }
}
