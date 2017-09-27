using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMario.Enums;
using SuperMario.SpriteFactories;

namespace SuperMario.AbstractClasses
{
    public class BlockState : IBlockState
    {
        public ISprite StateSprite { get; set; }
        public BlockType BlockType { get; set; }
        public Shape MarioShape { get; set; }

        public BlockState(BlockType type)
        {
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
            BlockType = type;
        }

        public void ChangeToUsedBlock()
        {
            BlockType = BlockType.Used;
            StateSprite = BlockSpriteFactory.Instance.CreateUsedBlock();
        }

        public void ChangeToBrickBlock()
        {
            BlockType = BlockType.Brick;
            StateSprite = BlockSpriteFactory.Instance.CreateBrickBlock();
        }

        public void ChangeToHiddenBlock()
        {
            BlockType = BlockType.Hidden;
            StateSprite = BlockSpriteFactory.Instance.CreateHiddenBlock();
        }

        public void ChangeToQuestionBlock()
        {
            BlockType = BlockType.Question;
            StateSprite = BlockSpriteFactory.Instance.CreateQuestionBlock();
        }

        public void BlockBumpUp()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
