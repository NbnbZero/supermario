using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class RunningRightSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public RunningRightSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Small;
            Mario.Acceleration = new Vector2(0.25f, Mario.Acceleration.Y);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningRightStarSmallMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Swim()
        {
            Mario.State = new SwimmingRightSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y );

        }

        public override void Crouch()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningRightBigMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && !Mario.IsInWater && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleRightSmallMarioState(Mario);
            }
            if (Mario.IsInAir && Mario.IsInWater && Mario.State.MarioPosture != Posture.Swimming)
            {
                Mario.State = new SwimmingRightSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}
