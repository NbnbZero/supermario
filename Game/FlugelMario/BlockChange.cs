using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using SuperMario.Enums;

namespace SuperMario
{
    class BlockChange : IBlockStateChange
    {
        public void Execute(InputState state, IBlockState BlockState, Vector2 BlockLocation)
        {
            if (BlockState != null)
            {
                switch (state)
                {
                    case InputState.ChangeToUsed:
                        BlockState.ChangeToUsedBlock();
                        break;
                    case InputState.BumpUp:
                        BlockState.BlockBumpUp(BlockLocation);
                        break;
                    case InputState.ChangeToVisible:
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
}
