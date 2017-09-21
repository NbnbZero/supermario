using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class IdleLeftSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public IdleLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Stand;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Small;
        }

        public override void ChangeToLeft()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}
