using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class CrouchLeftBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Crouch;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
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
