using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sound;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class IdleRightSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public IdleRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Small;
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }
        public override void RunLeft()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void RunRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightSmallMarioState(Mario);
            }
        }

        public override void Swim()
        {
            Mario.State = new SwimmingRightSmallMarioState(Mario);
            SoundManager.Instance.PlaySmallJumpSound();
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

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightSmallMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (!Mario.IsInAir)
            { 
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
}
