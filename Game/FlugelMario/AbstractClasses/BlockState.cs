using FlugelMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.AbstractClasses
{
    public abstract class BlockState : IBlockState
    {
        public enum BlockTypeEnums { Question, Used, Brick, Floor, Stair, Hidden, None }

        public BlockTypeEnums BlockType { get; set; } = BlockTypeEnums.None;
        public ISprite StateSprite { get; set; }
        public IMario Mario { get; set; }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
        }

        public void Update()
        {
            
        }
    }
}
