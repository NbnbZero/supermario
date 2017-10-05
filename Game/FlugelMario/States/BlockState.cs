using FlugelMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlugelMario.Enums;
using FlugelMario.SpriteFactories;

namespace FlugelMario.AbstractClasses
{
    public class BlockState : IBlockState
    {
        public ISprite StateSprite { get; set; }
        public BlockType type { get; set; }

        public BlockState(BlockType Type)
        {
            type = Type;
            if (type == BlockType.Question)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateQuestionBlock();
            }
            else if (type == BlockType.Used)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateUsedBlock();
            }
            else if (type == BlockType.Brick)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateBrickBlock();
            }
            else if (type == BlockType.Hidden)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateHiddenBlock();
            }
        }

        public void ChangeToUsedBlock()
        {
            type = BlockType.Used;
            StateSprite = BlockSpriteFactory.Instance.CreateUsedBlock();
        }

        public void ChangeToBrickBlock()
        {
            type = BlockType.Brick;
            StateSprite = BlockSpriteFactory.Instance.CreateBrickBlock();
        }

        public void BlockBumpUp()
        {
   
        }
        public void BreakBrickBlock()
        {

        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
