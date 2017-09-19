

namespace FlugelMario.Interfaces
{
    interface IMarioState
    {
        ISprite StateSprite { get; set; }
        void ChangeToRight();
        void JumpOrStand();
        void ChangeSizeToBig();
        void ChangeSizeToSmall();
        void Terminated();
        void ChangeToLeft();
        void Crouch();
        void ChangeFireMode();
    }
}
