using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class IdleRightFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public IdleRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Fire;

        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void RunRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightFireMarioState(Mario);
            }
        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchRightFireMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightFireMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (Mario.Velocity.X >= 0.75f)
            {
                Mario.Acceleration = new Vector2(-0.75f, Mario.Acceleration.Y);
            }
            else if (Mario.Velocity.X <= -0.75f)
            {
                Mario.Acceleration = new Vector2(0.75f, Mario.Acceleration.Y);
            }
            else
            {
                Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
                Mario.Velocity = new Vector2(0, Mario.Velocity.Y);
            }
        }
    }
}