using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    internal class JumpLeftBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = false;
        public JumpLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftBigMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
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