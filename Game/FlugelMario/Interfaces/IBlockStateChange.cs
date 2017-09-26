using FlugelMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario
{
    public interface IBlockStateChange
    {
        void Execute(InputState state, IBlockState BlockState);
    }
}
