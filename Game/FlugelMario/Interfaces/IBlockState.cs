using FlugelMario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.Interfaces
{
    public interface IBlockState
    {
        ISprite StateSprite { get; set; }
        BlockType BlockType { get; set; }      
        Shape MarioShape { get; set; }
        void ChangeToUsedBlock(Vector2 BlockLocation);
        void ChangeToBrickBlock(Vector2 BlockLocation);
        void ChangeToQuestionBlock(Vector2 BlockLocation);
        void BlockBumpUp(Vector2 BlockLocation);
        void BreakBrickBlock(Vector2 BlockLocation);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
