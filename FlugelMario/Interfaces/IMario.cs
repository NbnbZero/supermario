using Microsoft.Xna.Framework;

namespace FlugelMario.Interfaces
{
    public interface IMario
    {
        IMarioState State { get; set; }
    }
}
