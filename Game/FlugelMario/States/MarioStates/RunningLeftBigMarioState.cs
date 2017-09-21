using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    class RunningLeftBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public RunningLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }
    }
}
