using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class JumpRightSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public JumpRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Small; 
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpRightFireMarioState(Mario);}

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpRightBigMarioState(Mario); }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}
