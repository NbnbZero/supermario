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
        ISprite StateSprite { get; set; }
        BlockType type { get; set; }      
        void ChangeToUsedBlock();
        void ChangeToBrickBlock();
        Vector2 BlockBumpUp(Vector2 location);
        void BreakBrickBlock();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
