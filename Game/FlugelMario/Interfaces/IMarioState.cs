using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;

namespace SuperMario.Interfaces
{
    public interface IMarioState
    {   
        ISprite StateSprite { get; set; }
        Posture MarioPosture { get; set; }
        Direction MarioDirection { get; set; }
        Shape MarioShape { get; set; }



        bool IsStar { get; }
        void JumpOrStand();
        void ChangeSizeToBig();
        void ChangeSizeToSmall();
        void Crouch();
        void ChangeFireMode();
        void Terminated();     
        void ChangeToLeft();
        void ChangeToRight();
        void ChangeStarMode();
        void MarioShapeChange(Shape newShape);
        void Update(); 
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
