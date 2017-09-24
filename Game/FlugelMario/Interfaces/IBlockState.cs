﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static FlugelMario.AbstractClasses.BlockState;
using static FlugelMario.AbstractClasses.MarioState;

namespace FlugelMario.Interfaces
{
    public interface IBlockState
    {
        BlockTypeEnums BlockType { get; set; }
        ISprite StateSprite { get; set; }
   
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}