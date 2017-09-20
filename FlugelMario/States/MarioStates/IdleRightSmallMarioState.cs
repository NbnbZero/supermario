using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleRightSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public IdleRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Small;
        }

        public override void ChangeToLeft()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            Mario.State = new RunningRightSmallMarioState(Mario);         
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}
