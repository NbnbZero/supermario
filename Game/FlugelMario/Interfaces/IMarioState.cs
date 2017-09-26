using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario.Enums;
using Microsoft.Xna.Framework.Input;

namespace FlugelMario.Interfaces
{
    public interface IMarioState
    {   
        ISprite StateSprite { get; set; }
        Posture MarioPosture { get; set; }
        Direction MarioDirection { get; set; }
        Shape MarioShape { get; set; }
        void Jump();
        void ChangeSizeToBig();
        void ChangeSizeToSmall();
        void Crouch();
        void ChangeFireMode();
        void Terminated();
        void Update(); 
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void RunLeft();
        void RunRight();
        void BeIdle();
        void BeIdle(InputState state);
    }
}
