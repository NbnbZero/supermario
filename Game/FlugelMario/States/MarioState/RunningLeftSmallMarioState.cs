using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class RunningLeftSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public RunningLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Small;
            Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y);
        }

        public override void RunRight()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -8);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }
        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarSmallMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != Posture.Jump) //falling down
            {
                Mario.State = new IdleLeftSmallMarioState(Mario);
            }

            base.Update();
        }
    }
}
