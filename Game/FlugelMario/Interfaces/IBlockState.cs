using SuperMario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface IBlockState
    {
        Sprite StateSprite { get; set; }
        BlockType BlockType { get; set; }      
        Shape MarioShape { get; set; }
        void ChangeToUsedBlock();
        void ChangeToBrickBlock();
        Vector2 BlockBumpUp(Vector2 blockLocation);
        void BreakBrickBlock();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
