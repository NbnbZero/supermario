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
    class IdleLeftStarBigMarioState : MarioState
    {
        public override bool IsStar { get; } = true;

        public IdleLeftStarBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftStarBigMarioSprite();
            this.MarioPosture = Posture.Stand;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.StarBig;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleLeftBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new RunningLeftStarBigMarioState(Mario);
            }
        }

        public override void ChangeToRight()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
        }

        public override void Crouch()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new CrouchLeftStarMarioState(Mario);
            }
        }

        public override void JumpOrStand()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new JumpLeftStarBigMarioState(Mario);
                Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
            }
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleLeftStarSmallMarioState(Mario);
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
