using SuperMario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario
{
    public interface IBlockStateChange
    {
        void Execute(InputState state, IBlockState BlockState, Vector2 BlockLocation);
    }
}
