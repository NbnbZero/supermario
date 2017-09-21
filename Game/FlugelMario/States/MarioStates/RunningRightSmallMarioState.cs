using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class RunningRightSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public RunningRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Small;
        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningRightBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}
