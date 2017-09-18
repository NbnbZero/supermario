using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Interfaces
{
    interface IController
    {
        void Run();

        void Crouch();

        void Jump();
    }
}
