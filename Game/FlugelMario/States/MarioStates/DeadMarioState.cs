using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class DeadMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public DeadMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            this.MarioPosture = MarioPostureEnums.Dead;
            this.MarioDirection = MarioDirectionEnums.Dead;
            this.MarioShape = MarioShapeEnums.Dead;
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
        }

        public override void JumpOrStand()
        {
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

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }
    }
}
