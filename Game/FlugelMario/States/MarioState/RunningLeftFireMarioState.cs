using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sound;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class RunningLeftFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public RunningLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftFireMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Fire;
            Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X,-7);
            Mario.Acceleration = new Vector2(-Mario.Velocity.X, Mario.Acceleration.Y);
        }

        public override void Swim()
        {
            Mario.State = new SwimmingLeftFireMarioState(Mario);
            SoundManager.Instance.PlaySmallJumpSound();
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && !Mario.IsInWater && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
            }

            if (Mario.IsInAir && Mario.IsInWater && Mario.State.MarioPosture != Posture.Swimming)
            {
                Mario.State = new SwimmingLeftFireMarioState(Mario);
            }
            base.Update();

        }
    }
}