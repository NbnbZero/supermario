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
        private int counter = 0;

        public Sprite StateSprite { get; set; }
        public BlockType BlockType { get; set; }
        public Shape MarioShape { get; set; }
        public int Counter { get => counter; set => counter = value; }

        public BlockState(BlockType Type)
        {
            if (Type == BlockType.Question)
            {
                //StateSprite = BlockSpriteFactory.Instance.CreateQuestionBlock(StateSprite.Location);
            }
            else if (Type == BlockType.Used)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateUsedBlock(StateSprite.Location, null);
            }
            else if (Type == BlockType.Brick)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateBrickBlock(StateSprite.Location, null);
            }
            else if (Type == BlockType.Hidden)
            {
                StateSprite = BlockSpriteFactory.Instance.CreateHiddenBlock();
            }
        }

        public void ChangeToUsedBlock()
        {
            BlockType = BlockType.Used;
            StateSprite = BlockSpriteFactory.Instance.CreateUsedBlock(StateSprite.Location, null);
        }

        public void ChangeToBrickBlock()
        {
            BlockType = BlockType.Brick;
            StateSprite = BlockSpriteFactory.Instance.CreateBrickBlock(StateSprite.Location, null);
        }
        public Vector2 BlockBumpUp(Vector2 blockLocation)
        {
            if (Counter >=0 && Counter < 30)
            {
                blockLocation.Y--;
                Counter++;
            }
            else if (Counter >= 30 && Counter < 60)
            {
                blockLocation.Y++;
                Counter++;
            }

            return blockLocation;
        }

        public void BreakBrickBlock()
        {
            StateSprite.Update();
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
