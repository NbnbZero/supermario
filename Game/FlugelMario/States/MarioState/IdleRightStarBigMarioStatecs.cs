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
    class IdleRightStarBigMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public IdleRightStarBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightStarBigMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.StarBig;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
        }

        public override void RunRight()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningRightStarBigMarioState(Mario);
            }
        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchRightStarMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpRightStarBigMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
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

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            base.Update();
            if (Mario.IsInAir) return;
            if (Mario.Velocity.X >= GameData.MarioCriticalSpeed)
            {
                Mario.Acceleration = new Vector2(-GameData.MarioCriticalSpeed, Mario.Acceleration.Y);
            }
            else if (Mario.Velocity.X <= -GameData.MarioCriticalSpeed)
            {
                Mario.Acceleration = new Vector2(GameData.MarioCriticalSpeed, Mario.Acceleration.Y);
            }
            else
            {
                Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
                Mario.Velocity = new Vector2(0, Mario.Velocity.Y);
            }
        }
    }
}
