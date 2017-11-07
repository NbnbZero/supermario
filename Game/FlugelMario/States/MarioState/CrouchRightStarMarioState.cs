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
    class CrouchRightStarMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public CrouchRightStarMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightStarMarioSprite();
            this.MarioPosture = Posture.Crouch;
            this.MarioDirection = Direction.Right;
            this.MarioShape =Shape.StarBig;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new CrouchLeftStarMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightStarBigMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleRightStarBigMarioState(Mario);
            }
            else
            {
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
            base.Update();

        }
    }
}
