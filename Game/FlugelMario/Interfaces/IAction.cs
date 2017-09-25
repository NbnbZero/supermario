using FlugelMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario
{
    interface IAction
    {
        void Execute(InputState state, IMarioState marioState);
    }
}
