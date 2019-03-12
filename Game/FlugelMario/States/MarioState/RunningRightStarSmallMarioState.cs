using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.MarioStates
{
    class RunningRightStarSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public RunningRightStarSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightStarSmallMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.StarSmall;
            Mario.Acceleration = new Vector2(0.25f, Mario.Acceleration.Y);

        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpRightStarSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningRightSmallMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningRightBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningRightStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleRightStarSmallMarioState(Mario);
            }
            base.Update();

        }
    }
}
