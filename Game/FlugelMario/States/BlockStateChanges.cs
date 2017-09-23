using FlugelMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.AbstractClasses;
using Microsoft.Xna.Framework.Input;

namespace FlugelMario.States
{
    public class BlockStateChanges : IBlockStateChanges
    {
        public BlockState.BlockTypeEnums BlockType { get; set; }
        public IController KeyboadrController { get; set; }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift))
            {
                if (keyboard.IsKeyDown(Keys.OemQuestion))
                {
                    BlockType = BlockState.BlockTypeEnums.Question;
                }
                
            }
            else if (keyboard.IsKeyDown(Keys.X))
            {
                BlockType = BlockState.BlockTypeEnums.Used;
            }
            else if (keyboard.IsKeyDown(Keys.B))
            {
                BlockType = BlockState.BlockTypeEnums.Brick;
            }
            else if (keyboard.IsKeyDown(Keys.H))
            {
                BlockType = BlockState.BlockTypeEnums.Hidden;
            }
        }
    }
}
