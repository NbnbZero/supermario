using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;

namespace FlugelMario
{
    class BlockChange : IBlockStateChange
    {
        public void Execute(InputState state, IBlockState BlockState)
        {
            switch (state)
            {
                case InputState.ChangeToUsed:
                    BlockState.ChangeToUsedBlock();
                    break;
                case InputState.BumpUp:
                    BlockState.BlockBumpUp();
                    break;
                case InputState.ChangeToVisable:
                    BlockState.ChangeToBrickBlock();
                    break;
                default:                    
                    break;
            }
        }
    }
}
