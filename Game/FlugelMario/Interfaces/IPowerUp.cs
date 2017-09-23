using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static FlugelMario.AbstractClasses.MarioState;

namespace FlugelMario.Interfaces
{
    public interface IPowerUp
    {
        MarioShapeEnums MarioShape { get; set; }
        IController KeyboadrController { get; set; }
        void Update();
    }
}
