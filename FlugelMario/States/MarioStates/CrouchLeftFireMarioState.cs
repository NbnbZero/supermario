using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class CrouchLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
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
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }
    }
}
