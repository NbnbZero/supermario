using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class IdleLeftSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public IdleLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Small;
        }

        public override void RunLeft()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningLeftSmallMarioState(Mario);
            }
        }

        public override void RunRight()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpLeftSmallMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, -8);
            }
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleLeftStarSmallMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
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
