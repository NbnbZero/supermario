using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Interfaces
{
    public interface IBlock : IGameObject
    {
        void Trigger();
    }
}
