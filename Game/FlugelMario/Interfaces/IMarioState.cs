using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario.Enums;

namespace FlugelMario.Interfaces
{
    public interface IMarioState
    {   
        ISprite StateSprite { get; set; }
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
