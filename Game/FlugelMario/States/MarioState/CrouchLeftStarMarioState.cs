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
    class CrouchLeftStarMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public CrouchLeftStarMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftStarMarioSprite();
            this.MarioPosture = Posture.Crouch;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.StarBig;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void ChangeToLeft()
        {
        }

        public override void ChangeToRight()
        {
            Mario.State = new CrouchRightStarMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
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
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleLeftBigMarioState(Mario);
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
