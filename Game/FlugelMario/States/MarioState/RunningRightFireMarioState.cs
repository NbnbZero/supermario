using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class RunningRightFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public RunningRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightFireMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Fire;
            if (!Mario.IsInWater)
            {
                Mario.Acceleration = new Vector2(0.25f, Mario.Acceleration.Y);
            }
            else
            {
                Mario.Acceleration = new Vector2(0.25f, Mario.Acceleration.Y + GameData.Float);
            }
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningRightBigMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightFireMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }
        public override void Swim()
        {
            Mario.State = new SwimmingRightFireMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);

        }

        public override void Crouch()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningRightSmallMarioState(Mario);
        }
        public override void ChangeStarMode()
        {
            Mario.State = new RunningRightStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && !Mario.IsInWater && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleRightFireMarioState(Mario);
            }
            if (Mario.IsInAir && Mario.IsInWater && Mario.State.MarioPosture != Posture.Swimming)
            {
                Mario.State = new SwimmingRightFireMarioState(Mario);
            }
            base.Update();
        }
    }
}