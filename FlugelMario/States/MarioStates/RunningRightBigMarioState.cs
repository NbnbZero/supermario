using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class RunningRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public RunningRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Big;
        }


        public override void ChangeToLeft()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightBigMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningRightFireMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningRightSmallMarioState(Mario);
        }
    }
}
