using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;

namespace FlugelMario.States.MarioStates
{
    internal class JumpLeftSmallMarioState : MarioState
    {
        private const bool isBig = false;
        private const bool isCrouching = false;
        public JumpLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftSmallMarioSprite();
            this.MarioPosture = MarioPostureEnums.Jump;
            this.MarioDirection = MarioDirectionEnums.Left;
            this.MarioShape = MarioShapeEnums.Small;
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
            Mario.State = new JumpLeftFireMarioState(Mario);}

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);}

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }
    }
}