using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Interfaces
{
    public interface IMario
    {
        IMarioState State { get; set; }
    }
}
