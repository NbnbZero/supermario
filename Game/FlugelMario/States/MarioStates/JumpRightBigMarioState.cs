using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class JumpRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public JumpRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Big;
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
            Mario.State = new JumpRightFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }
    }
}