using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class IdleLeftBigMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public IdleLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
        }

        public override void RunLeft()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningLeftBigMarioState(Mario);
            }
        }

        public override void RunRight()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void SwimLeft()
        {
            Mario.State = new IdleInWaterLeftBigMarioState(Mario);

        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchLeftBigMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpLeftBigMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (Mario.Velocity.X >= 0.75f)
            {
                Mario.Acceleration = new Vector2(-0.75f, Mario.Acceleration.Y);
            }
            else if (Mario.Velocity.X <= -0.75)
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