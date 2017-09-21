using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class CrouchRightFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }
        public override void ChangeToLeft()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void Crouch()
        {
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
