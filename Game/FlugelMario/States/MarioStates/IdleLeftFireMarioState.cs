using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public IdleLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
        }
        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }
    }
}