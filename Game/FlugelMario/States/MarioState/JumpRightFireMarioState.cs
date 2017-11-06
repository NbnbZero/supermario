using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class JumpRightFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public JumpRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightFireMarioSprite();
            this.MarioPosture = Posture.Jump;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Fire;
            mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            mario.IsInAir = true;
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpRightStarBigMarioState(Mario);
        }
        public override void RunLeft()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
        }

        public override void RunRight()
        {
            Mario.Location = new Vector2(Mario.Destination.X + 1, Mario.Destination.Y);
        }

        public override void JumpOrStand()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpRightBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleRightFireMarioState(Mario);
            }
            base.Update();
        }
    }
}