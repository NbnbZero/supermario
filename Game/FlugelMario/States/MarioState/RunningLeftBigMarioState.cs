using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    class RunningLeftBigMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public RunningLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftBigMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Big;
            Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
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
            if (Mario.IsInAir && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleLeftBigMarioState(Mario);
            }
            base.Update();
        }
    }
}
