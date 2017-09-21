using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    public class JumpLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public JumpLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftFireMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
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

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }
    }
}