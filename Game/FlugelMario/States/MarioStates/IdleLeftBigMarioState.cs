using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleLeftBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public IdleLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);     
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
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