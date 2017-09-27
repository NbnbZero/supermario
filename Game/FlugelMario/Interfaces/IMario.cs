using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IMario
    {
        IMarioState State { get; set; }
    }
}
