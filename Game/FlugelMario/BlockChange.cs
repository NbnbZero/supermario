using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;
using Microsoft.Xna.Framework;
using FlugelMario.Enums;

namespace FlugelMario
{
    class BlockChange : IBlockStateChange
    {
        public void Execute(InputState state, IBlockState BlockState, Vector2 BlockLocation)
        {
            switch (state)
            {
                case InputState.ChangeToUsed:
                    BlockState.ChangeToUsedBlock(BlockLocation);
                    break;
                case InputState.BumpUp:
                    BlockState.BlockBumpUp(BlockLocation);
                    break;
                case InputState.ChangeToVisable:
                    BlockState.ChangeToBrickBlock(BlockLocation);
                    break;
                case InputState.BreakBrick:
                    BlockState.BreakBrickBlock(BlockLocation);
                    break;
                default:                    
                    break;
            }
        }
    }
}
