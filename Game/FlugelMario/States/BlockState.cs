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

        public void ChangeToUsedBlock(Vector2 BlockLocation)
        {
            BlockType = BlockType.Used;           
            Game1.usedBlockLocations.Add(BlockLocation);
            Game1.questionBlockLocations.Remove(BlockLocation);
        }

        public void ChangeToBrickBlock(Vector2 BlockLocation)
        {
            BlockType = BlockType.Brick;
            Game1.brickBlockLocations.Add(BlockLocation);
        }
        public void ChangeToQuestionBlock(Vector2 BlockLocation)
        {
            BlockType = BlockType.Question;
        }

        public void BlockBumpUp(Vector2 BlockLocation)
        {
            throw new NotImplementedException();
        }

        public void BreakBrick(Vector2 BlockLocation)
        {
            throw new NotImplementedException();
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
