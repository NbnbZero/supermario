using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class RunningLeftSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public RunningLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Running;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Small;
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}
