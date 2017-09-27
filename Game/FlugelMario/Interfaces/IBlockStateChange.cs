using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public interface IBlockStateChange
    {
        void Execute(InputState state, IBlockState blockState);
    }
}
