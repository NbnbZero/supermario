using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public IdleRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }
        public override void ChangeToRight()
        {
            Mario.State = new RunningRightBigMarioState(Mario);
        }
        public override void Crouch()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }
        public override void JumpOrStand()
        {
            Mario.State = new JumpRightBigMarioState(Mario);
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
