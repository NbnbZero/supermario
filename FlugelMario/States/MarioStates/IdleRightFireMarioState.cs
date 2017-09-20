using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleRightFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public IdleRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Fire;

        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            Mario.State = new RunningRightFireMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }
    }
}