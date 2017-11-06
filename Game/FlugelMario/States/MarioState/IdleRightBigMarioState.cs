using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class IdleRightBigMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public IdleRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }
        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }
        public override void RunRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightBigMarioState(Mario);
            }
        }
        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchRightBigMarioState(Mario);
            }
        }
        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightBigMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, -8);
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
