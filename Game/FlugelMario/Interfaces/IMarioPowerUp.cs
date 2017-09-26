using FlugelMario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Interfaces
{
    public interface IMarioPowerUp
    {
        Shape MarioShape { get; set; }
        Controller KeyboadrController { get; set; }
        void Update();
    }
}
