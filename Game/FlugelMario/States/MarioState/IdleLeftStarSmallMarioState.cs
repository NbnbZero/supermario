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
    class IdleLeftStarSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public IdleLeftStarSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftStarSmallMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.StarSmall;

        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningLeftStarSmallMarioState(Mario);
            }
        }

        public override void RunRight()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpLeftStarSmallMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
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
