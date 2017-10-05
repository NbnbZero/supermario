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
        public void Execute(InputState state, IBlockState BlockState, Vector2 location)
        {
            switch (state)
            {
                case InputState.ChangeToUsed:
                    BlockState.ChangeToUsedBlock();
                    break;
                case InputState.BumpUp:
                    BlockState.BlockBumpUp(location);
                    break;
                case InputState.ChangeToVisable:
                    BlockState.ChangeToBrickBlock();
                    break;
                case InputState.BreakBrick:
                    BlockState.BreakBrickBlock();
                    break;
                default:                    
                    break;
            }
        }
    }
}
