using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario
{
    class BlockChange : IBlockStateChange
    {
        public void Execute(InputState state, IBlockState BlockState)
        {
            if (BlockState != null)
            {
                switch (state)
                {
                    case InputState.ChangeToUsed:
                        BlockState.ChangeToUsedBlock();
                        break;
                    case InputState.BumpUp:
                        BlockState.BlockBumpUp();
                        break;
                    case InputState.ChangeToVisible:
                        BlockState.ChangeToBrickBlock();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
