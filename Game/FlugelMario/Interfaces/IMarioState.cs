using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static FlugelMario.AbstractClasses.MarioState;

namespace FlugelMario.Interfaces
{
    public interface IMarioState
    {
        MarioPostureEnums MarioPosture { get; set; }
        MarioDirectionEnums MarioDirection { get; set; }
        MarioShapeEnums MarioShape { get; set; }
        ISprite StateSprite { get; set; }
        void ChangeToRight();
        void JumpOrStand();
        void ChangeSizeToBig();
        void ChangeSizeToSmall();
        void ChangeToLeft();
        void Crouch();
        void ChangeFireMode();
        void Terminated();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
