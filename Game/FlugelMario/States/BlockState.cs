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
        public BlockType type { get; set; }

        int count = 0;

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

        public Vector2 BlockBumpUp(Vector2 location)
        {
            if (count >= 0 && count < 30)
            {
                location.Y--;
                count++;
            }
            else if (count >= 30 && count < 60)
            {
                location.Y++;
                count++;
            }

            return location;
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
