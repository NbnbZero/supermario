using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class CrouchRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Right;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
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
